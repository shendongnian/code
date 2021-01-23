    class Program
    {
        static readonly AsyncAutoResetEvent _resetEvent = new AsyncAutoResetEvent(); 
        static void Main(string[] args)
        {
            // Start the asynchronous fetching loop...
            RunAsync();
            
            Task.Run(async () =>
            {
                // Simulate fast notifications 
                for (int i = 0; i < 15; i++)
                {
                    OnNotification(i);
                    await Task.Delay(100);
                }
                // Simulate a pause of notifications 
                await Task.Delay(2000);
                // Simulate fast notifications 
                for (int i = 0; i < 15; i++)
                {
                    OnNotification(i);
                    await Task.Delay(100);
                }
            });
            Console.ReadKey();
        }
        static void OnNotification(int index)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + " OnNotification " + index);
            // This will unlock the current or next WaitAsync on the _resetEvent
            _resetEvent.Set();
        }
        static async Task RunAsync()
        {
            // Uncomment this if you want to wait for a first notification before fetching.
            // await _resetEvent.WaitAsync();    
            
            while (true)
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + " Fetching...");
                
                // Simulate long fetching
                await Task.Delay(1000);
                // Wait for a new notification before doing another fetch
                await _resetEvent.WaitAsync();    
            }
        }
    }
