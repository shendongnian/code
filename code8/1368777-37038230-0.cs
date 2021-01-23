    public GameObject spawnType = null;
    public float ScaleMin = 0.5f;
    public float ScaleMax = 2.0f;
    public Color OriginalColorforSpawned;
    void Awake ()
    {
        OriginalColorforSpawned = new Color(Random.Range(1,255), Random.Range(1,255), Random.Range(1, 255));
        // this line will override that right away?!?!
        OriginalColorforSpawned = spawnType.GetComponent<Renderer>().sharedMaterial.color;
    }
