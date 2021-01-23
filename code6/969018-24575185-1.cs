	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Threading;
	namespace Performance
	{
		class PerformanceTest
		{
			PerformanceCounter memory;
			Timer timer;
			public PerformanceTest()
			{
				memory = new PerformanceCounter("Memory", "Available MBytes");
                // Get a new value every 10 seconds
				timer = new Timer(PerformanceTimer_Tick, null, 0, 10000);
			}
			static void Main(string[] args)
			{
				
				PerformanceTest pt = new PerformanceTest();
				Console.ReadLine();
			}
			private void PerformanceTimer_Tick(object sender)
			{
				Console.WriteLine("Memory Available: " + memory.NextValue().ToString() + "\n");
				// Force garbage collection
				GC.Collect();
			}
		}
	}
