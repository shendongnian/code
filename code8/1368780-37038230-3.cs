    public GameObject spawnType = null;
    public float ScaleMin = 0.5f;
    public float ScaleMax = 2.0f;
    public Color OriginalColorforSpawned;
    void Awake ()
    {
        OriginalColorforSpawned = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        spawnType.GetComponent<Renderer>().material.color = OriginalColorforSpawned;
    }
