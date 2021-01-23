    public class MyHub : Hub
    {     
        public void Start(string arg)
        {
            Task.Run(() =>
            {
                AVeryLongTask();
            });
        }
        
        //simulate a long task
        void AVeryLongTask()
        {
            for (int i = 0; i < 10000; i++)
            {
                Thread.Sleep(100);              
                Clients.Caller.ReportProgress("AVeryLongTask", i * 100 / 10000);
            }
        }
    }
