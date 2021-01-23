	class Program
	{
		static void Main(string[] args)
		{
			theMeter met = new theMeter();
			Enumerable.Range(0, 1000).AsParallel().ForAll((i) => met.CounterMeter());
			Console.ReadLine();
		}
	}
