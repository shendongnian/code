        class Program
        {
            static List<float> AvailableCPU = new List<float>();
            static List<float> AvailableRAM = new List<float>();
    
            protected static PerformanceCounter cpuCounter;
            protected static PerformanceCounter ramCounter;
            static List<PerformanceCounter> cpuCounters = new List<PerformanceCounter>();
            static int cores = 0;
            static void Main(string[] args)
            {
                cpuCounter = new PerformanceCounter();
                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";
    
                foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
                {
                    cores = cores + int.Parse(item["NumberOfCores"].ToString());
                }
    
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
    
                int procCount = System.Environment.ProcessorCount;
                for(int i = 0; i < procCount; i++)
                {
                    System.Diagnostics.PerformanceCounter pc = new System.Diagnostics.PerformanceCounter("Processor", "% Processor Time", i.ToString());
                    cpuCounters.Add(pc);
                }
    
                Thread c = new Thread(ConsumeCPU);
                c.IsBackground = true;
                c.Start();
    
                try
                {
                    System.Timers.Timer t = new System.Timers.Timer(1200);
                    t.Elapsed += new ElapsedEventHandler(TimerElapsed);
                    t.Start();
                    Thread.Sleep(10000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("catched exception");
                }
                Console.ReadLine();
    
            }
    
            public static void ConsumeCPU()
            {
                int percentage = 60;
                if (percentage < 0 || percentage > 100)
                    throw new ArgumentException("percentage");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                while (true)
                {
                    // Make the loop go on for "percentage" milliseconds then sleep the 
                    // remaining percentage milliseconds. So 40% utilization means work 40ms and sleep 60ms
                    if (watch.ElapsedMilliseconds > percentage)
                    {
                        Thread.Sleep(100 - percentage);
                        watch.Reset();
                        watch.Start();
                    }
                }
            }
    
            public static void TimerElapsed(object source, ElapsedEventArgs e)
            {
                float cpu = cpuCounter.NextValue();
                float sum = 0;
                foreach(PerformanceCounter c in cpuCounters)
                {
                    sum = sum + c.NextValue();
                }
                sum = sum / (cores);
                float ram = ramCounter.NextValue();
                Console.WriteLine(string.Format("CPU Value 1: {0}, cpu value 2: {1} ,ram value: {2}", sum, cpu, ram));
                AvailableCPU.Add(sum);
                AvailableRAM.Add(ram);
            }
    
        }
