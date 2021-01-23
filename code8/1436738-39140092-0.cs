	using System;
	using System.Threading;
	using System.Threading.Tasks;
	class ThreadTest
	{
		/// <summary>  DO NOT TOUCH ME DIRECTLY  </summary>
		private static int sum/* = 0 zero is default*/;
		private static int Add(int add) => Interlocked.Add(ref sum, add);
		private static int Increment() => Interlocked.Increment(ref sum);
		private static int Latest() => Interlocked.Add(ref sum, 0);
		private static void RunMe() => Increment();
		static void Main()
		{
			Task t1 = new Task(RunMe);
			Task t2 = new Task(RunMe);
			t1.Start();
			t2.Start();
			Task.WaitAll(t1, t2);
			Console.WriteLine(Latest().ToString());
			Console.ReadLine();
		}
	}
