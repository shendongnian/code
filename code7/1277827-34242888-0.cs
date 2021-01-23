    void Start(){
        for(int i = 0; i < poolItems.Count; i++){
            GameObject obj = poolItems[i].prefab;
            for (int j = 0; j < poolItems[i].startItems; j++){
                GameObject newObj = Create(obj); 
                newObj.GetComponent<IPoolItem>().Prefab = obj;
                newObj.SetActive(false);
                gameObjects.Add(newObj);
            }
        }
    }
