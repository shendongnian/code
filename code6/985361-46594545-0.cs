    // TRY THIS
    public class MyCPU
    {
        // This method that will be called when the thread is started
        public void Info()
        {
            /*
             * CPU time (or process time) is the amount of time for which a central processing unit (CPU) was used for processing instructions of a computer program or operating system
             */
            PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);
            for (int i64 = 0; i64 < 100; ++i64)
            {
				Console.WriteLine("CPU: " + (cpuCounter.NextValue() / Environment.ProcessorCount) + " %");
            }
        }
    };
