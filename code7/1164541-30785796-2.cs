    private void CountdownThread() {
        // Calculate the total running time
        int runningTime = time.Sum(x => Convert.ToInt32(x));
    
        // Convert to seconds
        int totalRunningTime = runningTime * 60;
    
        // New timer
        System.Timers.Timer t = new System.Timers.Timer(1000);
        t.Elapsed += (s, e) => {
    		totalRunningTime--;
    		// Update the label in the GUI
    		lblRunning.Dispatcher.BeginInvoke((Action)(() => {
    		    lblRunning.Content = TimeSpan.FromSeconds(totalRunningTime).ToString();
    		}));
    	};
    	// Start the timer!
    	t.Start();
    }   
     
