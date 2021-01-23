    float duration; //duration of movement
    float durationTime; //this will be the value used to check if Time.time passed the current duration set
    void Start()
    {
        StartMovement();
    }
    
    void StartMovement()
    {
        InvokeRepeating("MovementFunction", Time.deltaTime, Time.deltaTime); //Time.deltaTime is the time passed between two frames
        durationTime = Time.time + duration; //This is how long the invoke will repeat
    }
    
    void MovementFunction()
    {
        if(durationTime > Time.time)
        {
            //Movement
        } 
        else 
        {
            CancelInvoke("MovementFunction"); //Stop the invoking of this function
            return;
        }
    }
