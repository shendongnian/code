    private static HashSet<string> firstTimeSet = new HashSet<string>();
    
    public string singleRunKey;
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player"
            && firstTimeSet.Add(singleRunKey))
        { GetComponent<BoxCollider2D>().enabled = false; }
    }
