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
				var procDictionary = new Dictionary<string, float>();
				Process.GetProcesses().OrderBy(p => p.ProcessName).ToList().ForEach(p =>
				{
					try
					{
						var perf = new PerformanceCounter("Process", "% Processor Time", 
						    p.ProcessName, true);
						perf.NextValue();
						Thread.Sleep(100);
						var val = perf.NextValue();
						if (val > 0)
							procDictionary.Add(p.ProcessName,
							    val / Environment.ProcessorCount);
					}
					catch (InvalidOperationException) { /*ignored*/ }
				});
				procDictionary.OrderByDescending(d => d.Value).ToList()
				    .ForEach(d => Console.WriteLine("{0:00.00} - {1}", d.Value, d.Key));
				Console.ReadLine();
			}
		}
	}
