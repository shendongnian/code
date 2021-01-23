        static void Main(string[] args)
        {
            DoFoo();
            Console.ReadKey();
        }
        
        static async void DoFoo()
        {
            try
            {
                await Foo();
            }
            catch (Exception ex)
            {
                //This is where you can catch your exception
            }
        }
        static async Task Foo()
        {
            await MainTask().ContinueWith((Task someTask) =>
            {
                Console.WriteLine("Main State=" + someTask.Status.ToString() + " IsFaulted=" + someTask.IsFaulted + " isComplete=" + someTask.IsCompleted);
            }, TaskContinuationOptions.NotOnFaulted);
        }
        static async Task MainTask()
        {
           
            Console.WriteLine("MainStarted!");
            Task someTask = Task.Run(() =>
            {
                Console.WriteLine("SleepStarted!");
                Thread.Sleep(1000);
                Console.WriteLine("SleepEnded!");
            });
            await someTask;
            throw new Exception("CustomException!");
           
            Console.WriteLine("Waiting Ended!!");
            
           
        }
