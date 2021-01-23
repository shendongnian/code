    //In Your background task class
    public void Run(IBackgroundTaskInstance taskInstance)
    {
      BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
      initiate();
      deferral.Complete();
    }
    public async void initiate()
    {
       //some code 
       HttpClient client = new HttpClient();
       HttpResponseMessage responseMessage = await client.GetAsync(new Uri(url));      
    }
