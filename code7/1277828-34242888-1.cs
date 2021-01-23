     public GameObject Instantiate(GameObject obj, Vector3 position, Quaternion rotation){
        foreach(IPoolItem item in poolItems){
            if(item.activeSelf == true){continue;}
            if(item.Prefab == obj) { return item.gameObject;}
        }
        return null;
    }
