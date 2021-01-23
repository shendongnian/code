        HealthManager hManager;
    void OnTriggerEnter2D (Collider2D trigger)
    {
        if (hManager.totalHealth >= 3)
        {
            hManager.LoadHealthSprites();
            hManager.totalHealth--;
        }
        else
        {
            levelManager = GameObject.FindObjectOfType<LevelManager>();
            levelManager.LoadLevel("Lose");
        }
    }
    void Start()
    {
        hManager = hpManager.GetComponent<HealthManager>();
    }
