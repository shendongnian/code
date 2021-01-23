    //In Your background task class
    public async void Run(IBackgroundTaskInstance taskInstance)
    {
       BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
       await initiate(); 
       //Background task will wait for the initiate() to complete then call defferal.Complete().
       deferral.Complete();
    }
    public async Task initiate()
    {
      //some code 
      HttpClient client = new HttpClient();
      HttpResponseMessage responseMessage = await client.GetAsync(new Uri(url));      
    }
