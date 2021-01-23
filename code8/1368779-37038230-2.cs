    public GameObject spawnType = null;
    public float ScaleMin = 0.5f;
    public float ScaleMax = 2.0f;
    public Color OriginalColorforSpawned;
    void Awake ()
    {
        OriginalColorforSpawned = new Color(Random.Range(1,255), Random.Range(1,255), Random.Range(1, 255));
        spawnType.GetComponent<Renderer>().material.color = OriginalColorforSpawned;
    }
