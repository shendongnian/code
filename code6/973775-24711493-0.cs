	class Program
	{
		static void Main(string[] args)
		{
			var things = new List<Something>();
			var random = new Random(111);
			for (int i = 0; i < 100000; ++i)
			{
				things.Add(new Something(random.Next(2010, 2016)));
			}
			T1(things);
			T2(things);
			var sw = Stopwatch.StartNew();
			for (int i = 0; i < 100; ++i)
			{
				T1(things);
			}
			Console.WriteLine(sw.ElapsedMilliseconds);
			sw.Restart();
			for (int i = 0; i < 100; ++i)
			{
				T2(things);
			}
			Console.WriteLine(sw.ElapsedMilliseconds);
			Console.ReadLine();
		}
		private static void T1(List<Something> list)
		{
			var result = list.Where(x => x.ValidDate.Year == DateTime.Now.Year).ToList();
		}
		private static void T2(List<Something> list)
		{
			var yr = DateTime.Now.Year;
			var result = list.Where(x => x.ValidDate.Year == yr).ToList();
		}
	}
	class Something
	{
		public Something(int year)
		{
			this.ValidDate = new DateTime(year);
		}
		public DateTime ValidDate { get; private set; }
	}
