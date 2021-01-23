      var t = Task.Run(async delegate
              {
                 await Task.Delay(TimeSpan.FromSeconds(10));
                 return System.Diagnostics.Process.Start("http://www.stackoverflow.com");
              });
    
      // Here you can do whatever you want without waiting to that Task t finishes.
 
      t.Wait();// that's is a barrier and the code after t.Wait() will be executed only after t had returned.
      Console.WriteLine("Task returned with process {0}, t.Result); // in case System.Diagnostics.Process.Start fails t.Result should be null 
