    static Task<int> AsyncCheck()
    {
       Task t = Task.Factory.StartNew( () => 
        {
            Console.WriteLine("Start awesome work");
            Task d1 = Task.Delay(1000);
            d1.ContinueWith(t1 => {
              Console.WriteLine("Almost done");
              Task t2 = Task.Delay(1000);
              t2.ContinueWith( tt2 => {
                Console.WriteLine("Ok, done!");
              }
            }
        });
       //no dependecies on t, so just return straight away
       return Task.FromResult(42);
    }
    
    static void AsyncCall()
    {
        Task<int> result = AsyncCheck();
        result.ContinueWith( t => {
          Console.WriteLine(t.Result);
        })
    }
