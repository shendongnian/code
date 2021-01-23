    public float myTimer = 5.0f;
    public bool gameIsRunning; //you don't want to let the timer run while in pause
    void Update ()
    {
        if (myTimer > 0 && gameIsRunning) myTimer -= Time.deltaTime;
        else if (myTimer <= 0 && gameIsRunning) Debug.Log ("GAME OVER");
    }
