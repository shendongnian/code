    public Canvas GUICanvas;
    
    void Start()
    {
    
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("FallingCube"))
        {
            GUICanvas.gameObject.SetActive(true);
        }
    }
    
    void Update()
    {
    
    }
