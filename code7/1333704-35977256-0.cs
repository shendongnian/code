    public int score = 0;
    public int triggerCounter = 0;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "trigger1")
        {
            score++;
            triggerCounter++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "trigger1")
        {
            triggerCounter--;
        }
    }
    void Update()
    {
        if(triggerCounter <= 0)
        {
            score = 0;
            triggerCounter = 0;      // just for savety
        }
    }
