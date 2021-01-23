	public static void MethodA()
	{
		var list = new List<int>(Enumerable.Range(1, 10));
		for (int i = list.Count - 1; i >= 0; i--)
		{
			if (list[i] > 5)
				list.RemoveAt(i);
		}
	}
	public static void MethodB()
	{
		var list = new List<int>(Enumerable.Range(1, 10));
		foreach (var item in list.ToList())
		{
			if (item > 5)
				list.Remove(item);
		}
	}
	public static void MethodC()
	{
		var list = new List<int>(Enumerable.Range(1, 10));
		list.RemoveAll(x => x > 5);
	}
	public static void Measure(string meas, Action act)
	{
		GC.Collect();
		GC.WaitForPendingFinalizers();
		var st = new Stopwatch();
		st.Start();
		for (var i = 0; i < 10000000; i++)
			act();
		st.Stop();
		Console.WriteLine($"{meas}: {st.Elapsed}");
	}
	static void Main(string[] args)
	{
		Measure("A", MethodA);
		Measure("B", MethodB);
		Measure("C", MethodC);
	}
