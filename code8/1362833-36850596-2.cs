    void Start()
    {
        GameObject prefab = GameObject.Find("PrebabTest");
        Object GameObject2 = PrefabUtility.GetPrefabParent(prefab);
        string prefabPath = AssetDatabase.GetAssetPath(GameObject2);
        Debug.Log("Path: " + prefabPath);
    }
