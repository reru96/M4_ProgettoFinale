using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;
    private List<GameObject> pools = new List<GameObject>();
    private int amountToPool = 20;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pools.Add(obj);
        }
        
    }

    public GameObject GetPoolObject()
    {
        for(int i = 0;i < pools.Count;i++)
        {
            if(!pools[i].activeInHierarchy)
            {
                return pools[i];
            }
            
        }
        return null;
    }
   
}
