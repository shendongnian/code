    private static void StopLoop()
    {
        double[] source = MakeDemoSource(1000, 1);
        ConcurrentStack<double> results = new ConcurrentStack<double>();
        // i is the iteration variable. loopState is a  
        // compiler-generated ParallelLoopState
        Parallel.For(0, source.Length, (i, loopState) =>
        {
            // Take the first 100 values that are retrieved 
            // from anywhere in the source. 
            if (i < 100)
            {
                // Accessing shared object on each iteration 
                // is not efficient. See remarks. 
                double d = Compute(source[i]);
                results.Push(d);
            }
            else
            {
                loopState.Stop();
                return;
            }
        });
        Console.WriteLine("Results contains {0} elements", results.Count());
    }
