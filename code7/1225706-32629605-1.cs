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
					var procs = Process.GetProcesses().ToList();
					procs.ForEach(p => counterList.Add(new PerformanceCounter("Process", 
					    "% Processor Time", p.ProcessName, true)));
					counterList.ForEach(c =>
					{
						try
						{
							var percent = c.NextValue() / Environment.ProcessorCount;
							if (percent < 0.001)
								return;
							if (!procDict.ContainsKey(c.InstanceName))
								procDict.Add(c.InstanceName, percent);
							else
								procDict[c.InstanceName] = percent;
						}
						catch (InvalidOperationException) { }
					});
					Console.Clear();
					procDict.OrderByDescending(d => d.Value).ToList().ForEach(d => 
					    Console.WriteLine("{0:00.00}% - {1}", d.Value, d.Key));
					Thread.Sleep(1000);
				}
			}
		}
	}
