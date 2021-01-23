    public sealed class KatzBackgroundTask : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral = taskInstance.GetDeferral(); 
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            RawNotification notification = (RawNotification)taskInstance.TriggerDetails;
            string content = notification.Content;
            System.Diagnostics.Debug.WriteLine(content);
            await testLoop();
            _deferral.Complete();
        }
        async void testLoop()
        {
            await Task.Run(() =>
            {
               int myCounter = 0;
               for (int i = 0; i < 100; i++)
               {
                   myCounter++;
                   //String str = String.Format(": {0}", myCounter);
                  Debug.WriteLine("testLoop runtimeComponent : " + myCounter);
               }
           }
       )
    }
    
