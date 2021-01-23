    class LongRunningTask {
        private void LongRunningJob() {
            // Do some long running job
            // Implement cancellation/pause token
        }        
        public async Task StartAsync(IState state) {
            // Load previous state
            // Start LongRunningJob()
        }
        public async Task<IState> SuspendAsync() {
            // Stop LongRunningJob() using a token
            // Return current state, in case of termination
        }
        public async Task ResumeAsync() {
           // Resume LongRunningJob using a token
        }
    }
