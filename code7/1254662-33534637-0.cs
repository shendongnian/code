    float moveTime = 10.0f; // In seconds
    float moveTimer = 0.0f; // Used for keeping track of time
    bool moving = false; // Flag letting us know if we're moving
    float heightChange = 10.0f; // This is the delta
    
    // These will be assigned when a collision occurs
    Vector3 target; // our target position
    Vector3 startPos; // our starting position
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!moving)
        {
            // We set the target to be ten units above our current position
            target = transform.position + Vector3.up * heightChange;
            // And save our start position (because our actual position will be changing)
            startPos = transform.position;
            // Set the flag so that the movement starts
            moving = true;
        }
    }
    void Update()
    {
        // If we're currently moving and the movement hasn't finished
        if (moving && moveTimer < moveTime)
        {
            // Accumulate the frame time, making the timer tick up
            moveTimer += Time.deltaTime;
        
            // calculate our ratio ("t")
            float t = moveTimer / moveTime;
            transform.position = Vector3.Lerp(startPos, target, t);
        }
        else
        {
            // We either haven't started moving, or have finished moving
        }
    }
