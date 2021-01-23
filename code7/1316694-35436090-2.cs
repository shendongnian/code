    public void Start() {
        // Calling start on a running Stopwatch is a no-op.
        if(!isRunning) {
            startTimeStamp = GetTimestamp();                 
            isRunning = true;
        }
    }
