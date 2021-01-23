    public AggregateValues Compute()
    {
        //How do I parallize these?
        AggregateValues av = new AggregateValues();
        Task taskA = Task.Factory.StartNew(() => av.A = ComputeA());
        Task taskB = Task.Factory.StartNew(() => av.B = ComputeB());
        Task taskC = Task.Factory.StartNew(() => av.C = ComputeC());
        
        //Wait for ComputeA, ComputeB, ComputeC to be done
        Task.WaitAll(taskA, taskB, taskC);
        return av;
    }
