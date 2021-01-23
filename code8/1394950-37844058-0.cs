    public float xTile, yTile;
    public GameObject rope;
    Material ropeMat;
    
    void Start()
    {
        ropeMat = rope.GetComponent<MeshRenderer>().material;
    }
    
    void Update()
    {
        ropeMat.SetTextureScale("_MainTex", new Vector2(xTile, yTile));
    }
