	using System.Threading;
	using System.Diagnostics;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	namespace ParallelTest
	{
		static class Program
		{
			static readonly Stopwatch Stopwatch = new Stopwatch();
			static void Main()
			{
				Stopwatch.Start();
				var myList = new List<string>();
				for (var i = 0; i < 10000; i++)
					myList.Add(string.Format("String Item or Object Nr. {0:00000000}", i));
				Debug.WriteLine("End Create In-Memory List: {0}", Stopwatch.Elapsed);
				// NON-PARELLEL
				Stopwatch.Restart();
				myList.ForEach(item =>
				{
					// ... Do something
					Thread.Sleep(1);
				});
				Debug.WriteLine("NON-PARALLEL LIST: {0}", Stopwatch.Elapsed);
				// ------------------------------------------------------------------------
				// If you don't need to edit the collection at runtime you can use a normal 
				// list with Parallel options
				// PARALLEL (MULTITHREADED)
				// Example with unlimited Thread (CLR auto-manages, be careful 
				// with SQL-Connections)
				Stopwatch.Restart();
				Parallel.ForEach(myList, item =>
				{
					// ... Do something
					Thread.Sleep(1);
				});
				Debug.WriteLine("PARALLEL LIST: {0}", Stopwatch.Elapsed);
				// ------------------------------------------------------------------------
				// If you don't need to edit the collection at runtime you can use a normal 
				// list with Parallel options
				// PARALLEL WITH LIMITED THREADS
				// Example with 2 Threads
				Stopwatch.Restart();
				Parallel.ForEach(myList, 
					new ParallelOptions { MaxDegreeOfParallelism = 2 }, item =>
				{
					// ... Do something
					Thread.Sleep(1);
				});
				Debug.WriteLine("PARALLEL LIST 2 THREADS: {0}", Stopwatch.Elapsed);
				// ------------------------------------------------------------------------
				// If you need to make changes to the list during runtime you need to use 
				// a thread-safe collection type such as BlockingCollection
				// Avoid race-conditions
				// See examples under 
				// https://msdn.microsoft.com/en-us/library/dd997306(v=vs.110).aspx
			}
		}
	}
