	[BenchmarkTask(platform: BenchmarkPlatform.X86)]
	[BenchmarkTask(platform: BenchmarkPlatform.X64)]
	public class Test
	{
		private readonly List<int> list = Enumerable.Range(0, 1000000).ToList();
		[Benchmark]
		public void TestSearch()
		{
			Search(list, 999999);
		}
		[Benchmark]
		public void TestSearchGeneric()
		{
			SearchGeneric(list, 999999);
		}
		public static int Search<T>(List<T> a, T target) where T : IComparable
		{
			for (int i = 0; i < a.Count; i++)
			{
				if (target.CompareTo(a[i]) == 0)
					return i;
			}
			return -1;
		}
		public static int SearchGeneric<T>(List<T> a, T target) where T : IComparable<T>
		{
			for (int i = 0; i < a.Count; i++)
			{
				if (target.CompareTo(a[i]) == 0)
					return i;
			}
			return -1;
		}
	}
	
