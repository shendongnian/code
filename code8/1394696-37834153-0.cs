    public class MyClass : IEnumerable<int>
	{
		public List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
		public IEnumerator<int> GetEnumerator()
		{
			foreach (var i in ints)
			{
				yield return i;
			}
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this as IEnumerator;
		}
	}
