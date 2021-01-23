    public GameObject prefab;
    void Start(){
        string prefabPath = AssetDatabase.GetAssetPath(prefab);
        Debug.Log("Path: " + prefabPath);
    }
