    class TestableRunnable : IRunnable {
        public bool IsRunning {get;set;}
        public void ThreadFunction() {
            // Sleep
            // IsRunning=true
            // WaitOnShutdownMutex
            // IsRunning=false
        }
        public void Stop() {
           // Set shutdown mutex
        }
    }
  
    TestRunnableStartsThreadAndStops() {
        // Create Testable... Pass it to Runner
        // Validate testable isn't running
        // tell runner to start, 
        // Validate testable isn't running (it should be sleeping if it's in another thread)
        // sleep to give it time to start thread
        // validate it's running
        // call stop
        // validate that it blocked until after the state is stopped
    }
