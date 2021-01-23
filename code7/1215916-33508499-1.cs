    class Program
	{
		public static void InsertionWorker<T>(T[] data, int left, int right) where T : IComparable<T>
		{
			for (var i = left; i < right + 1; i++)
			{
				T tmp = data[i];
				int j;
				for (j = i - 1; j >= left && tmp.CompareTo(data[j]) < 0; j--)
				{
					data[j + 1] = data[j];
				}
				data[j + 1] = tmp;
			}
		}
		static void Main(string[] args)
		{
            // test data array
			var a = new[] {234, 2, 11111, 34, 24, 23, 4, 432, 42, 423, 1, 4, 123, 124, 32, 345, 45, 3, 7, 56,9999999};
			
            // Run insertion sort by provided boundaries
            InsertionWorker(a, 7, a.Length-1);
            // InsertionWorker(a, 0, 8);
			foreach (int t in a)
			{
				Console.WriteLine(t);
			}
			Console.ReadKey();
		}
	}
