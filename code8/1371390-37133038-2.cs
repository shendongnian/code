    private void SomeMainMethod()
    {
        System.Threading.ThreadPriority tp = System.Threading.ThreadPriority.Normal;
        try
        {
            tp = System.Threading.Thread.CurrentThread.Priority;
            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            SomeMethod();
            sw.Stop();
            Console.WriteLine("Time for SomeMethod = {0}ms", sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            SomeOtherMethod();
            sw.Stop();
            Console.WriteLine("Time for SomeOtherMethod= {0}ms", sw.ElapsedMilliseconds);
            //...
        }
        finally
        {
            System.Threading.Thread.CurrentThread.Priority = tp;
        }
    }
