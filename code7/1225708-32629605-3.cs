    using System;
    using System.Linq;
    using System.Threading;
    using System.Diagnostics;
    using System.Collections.Generic;
    namespace ProcessCount
    {
        static class Program
        {
            static void Main()
            {
                var procDict = new Dictionary<string, float>();
                var counterList = new List<PerformanceCounter>();
                while (true)
                {
                
                    Process.GetProcesses().ToList().ForEach(p => counterList
                        .Add(new PerformanceCounter("Process", "% Processor Time",
                            p.ProcessName, true)));
                    counterList.ForEach(c =>
                    {
                        try
                        {
                            // http://social.technet.microsoft.com/wiki/contents/articles/12984.understanding-processor-processor-time-and-process-processor-time.aspx
                            // This value is calculated over the base line of (No of Logical CPUS * 100), So this is going to be a calculated over a baseline of more than 100. 
                            var percent = c.NextValue() / Environment.ProcessorCount;
                            if (percent == 0)
                                return;
                            if (procDict.ContainsKey(c.InstanceName))
                                procDict[c.InstanceName] = percent;
                            else
                                procDict.Add(c.InstanceName, percent);
                        }
                        catch (InvalidOperationException) { /* some will fail */ }
                    });
                    Console.Clear();
                    procDict.OrderByDescending(d => d.Value).ToList()
                        .ForEach(d => Console.WriteLine("{0:00.00}% - {1}", d.Value, d.Key));
                    Thread.Sleep(1000);
                }
            }
        }
    }
