    //Start time measurement
    List<Task> TaskList = new List<Task>();
    for (int i = 0; i < 100; i++)
    {
      Task postTask = Task.Run(async () =>
      {
         WebHelper webRequest = new WebHelper();
         string response = await webRequest.MakePostRequest(client, "WebApi", dataToBeSent);
         Console.WriteLine(response);
      });
      TaskList.Add(postTask);
    }
    Task.WaitAll(TaskList.ToArray());
    //end time measurement
