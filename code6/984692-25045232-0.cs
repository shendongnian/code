    while(!StartServer.HasExited)
    {
           var t 1= Task.Run(() =>  Console.WriteLine(StartServer.StandardOutput.ReadLine()));
           var t2 = Task.Run(() => StartServer.StandardInput.WriteLine(Console.ReadLine()));
           Task.WaitAny(new[] { t1, t2 });
    }
