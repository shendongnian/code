    private TaskCompletionSource<bool> currentTask;
    
    private async Task GetURLs()
    {
        while (someCondition)
        {
            currentTask = new TaskCompletionSource<bool>();
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += WebClientDownloadString_Complete;
            webClient.DownloadStringAsync(address);
    
            await currentTask;
        }
    }
    
    private void WebClientDownloadString_Complete(...)
    {
        //Process completion
    
        //C# 6 null check
        curentTask?.TrySetValue(true);
    }
