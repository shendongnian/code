    public void DoTaskWork()
        {
            InitialTimeOut();
            Random rand = new Random();
            int operationTime = rand.Next(2000, 20000);
            while (true)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    throw new Exception("Cancellation requested.");
                }
                Thread.Sleep(operationTime);
            }
            _timer.Stop();
            Console.WriteLine("Thread {0} was finished...", ProcessObjectID);
        }
