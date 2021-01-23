    public GameObject thirdPerson; // you third person GameObject
    public int oldPosition = 5; // start (old) point
    public int newPosition = 10; // new point
    
    void Update()
    { 
        if (oldPosition <= newPosition)
        {
            oldPosition += Time.deltaTime;
        }
        thirdPerson.transform.position = new Vector3(oldPosition, 0, 0);
    }
