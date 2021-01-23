    public GameObject[] RedgeSets;
    private Object myist;
    
    const float incrementAmount = 5;
    float currentIncremenet;
    
    void Start()
    {
        currentIncremenet = incrementAmount;
    }
    
    void Update()
    {
        Vector3 addheight = new Vector3(0, currentIncremenet, 0);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(RedgeSets[UnityEngine.Random.Range(0, 3)], addheight, Quaternion.identity);
            currentIncremenet += incrementAmount; //Inrement the next Y axis(Increments by 5)
        }
    }
