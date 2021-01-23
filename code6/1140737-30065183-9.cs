    void Start()
    {
        Invoke("feedDog", 5);
        Debug.Log("Will feed dog after 5 seconds");
    }
    
    void feedDog()
    {
        Debug.Log("Now feeding Dog");
    }
