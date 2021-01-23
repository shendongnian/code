    public static void Main()
    {
        var cpuSample = new System.Diagnostics.PerformanceCounter("Processor", "% Processor Time", "_Total"); 
        while(true)
        {
           Thread.Sleep(1000);
           Console.WriteLine(cpuSample.NextValue() + " %");
        }
     }
