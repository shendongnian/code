    private GameObject reference;
    private List<GameObject> ballArray;
    void Start()
    {
        reference = GameObject.FindGameObjectWithTag("ball");
        ballArray = new List<GameObject>();
        start = false;
        for (int i = 0; i < amountOfBalls; i++)
        {
            ballArray.Add(Instantiate(reference));
            print("Initialized: " + (i + 1) + " times.");
            if (ballArray[i].GetComponent<Ball>().IsOffScreen())
            {
                print("Ball #" + (i + 1) + " is off screen");
            }
        }
    }
