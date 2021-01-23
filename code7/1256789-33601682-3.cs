    private async override void OnLaunched(LaunchActivatedEventArgs e) {
        // Check launch reason first
        // Read state from the disk
        await longRunningTask.StartAsyc(state);        
    }
    private async void OnResuming(object sender, object e) {
        await longRunningTask.ResumeAsync();        
    }
    private async void OnSuspending(object sender, SuspendingEventArgs e) {
        await longRunningTask.SuspendAsync();     
    }
