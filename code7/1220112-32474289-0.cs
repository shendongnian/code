    public void DoTaskWork()
    {
        InitialTimeOut();     
        Random rand = new Random();
        int operationTime = rand.Next(2000, 20000);
        // Thread.Sleep(operationTime); // this imitates a non-responsive operation
        // but this imitates a responsive operation:
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        while (!cancelToken.IsCancellationRequested
          && stopwatch.ElapsedMilliseconds < operationTime)
        {
            Thread.Sleep(10);
        }
        _timer.Stop();          
         Console.WriteLine("Thread {0} was finished...", ProcessObjectID);            
    }       
