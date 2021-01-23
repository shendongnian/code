    var timer = new SimpleTimer();
    timer.Start();
            
    //Prints the total time each iteration
    for(var i = 1; i <=1000; i++)
    {
        System.Threading.Thread.Sleep(5);
        Console.WriteLine("Loop " + i + ": Elasped Time = " + timer.ElaspedTime + " ms");
    }
    timer.Restart();
    //Prints roughly 5ms each iteration
    for (var i = 1; i <= 1000; i++)
    {
        System.Threading.Thread.Sleep(5);                
        Console.WriteLine("Loop " + i + ": Elasped Time = " + timer.ElaspedTime + " ms");
        timer.Restart();
    }
