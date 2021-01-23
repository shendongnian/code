    public GameObject[] allPrefabs;
    void Start()
    {
        allPrefabs = Resources.LoadAll<GameObject>("Prefabs");
    }
