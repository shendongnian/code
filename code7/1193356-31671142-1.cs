    class Program
	{
		static void Main(string[] args)
		{
			var input = Enumerable.Range(1, 60);
			using (var textWriter = File.AppendText("result.txt"))
			{
				foreach (var combination in input.CombinationsWithRepeat(10))
				{
					foreach (var digit in combination)
					{
						textWriter.Write(digit);
					}
					textWriter.WriteLine();
				}
			}
		}
	}
	public static class Extensions
	{
		public static IEnumerable<IEnumerable<T>> CombinationsWithRepeat<T>(this IEnumerable<T> elements, int k)
		{
			return k == 0 ? new[] { new T[0] } : elements.SelectMany((e, i) => elements.CombinationsWithRepeat(k - 1).Select(c => (new[] { e }).Concat(c)));
		}
	}
