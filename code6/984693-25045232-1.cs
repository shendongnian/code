    Task t1 = null, t2 = null;
    while(!StartServer.HasExited)
    {
           if (t1 == null || t1.IsCompleted)
               t 1= Task.Run(() =>  Console.WriteLine(StartServer.StandardOutput.ReadLine()));
           if (t2 == null || t2.IsCompleted)
               t2 = Task.Run(() => StartServer.StandardInput.WriteLine(Console.ReadLine()));
           Task.WaitAny(new[] { t1, t2 });
    }
