	public class MyClass : IEnumerable<int>
	{
		private List<int> _list = new List<int>();
		
		public void Add(int x)
		{
			Console.WriteLine(x);
			_list.Add(x);
		}
		
		public IEnumerator<int> GetEnumerator()
		{
			return _list.GetEnumerator();
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return _list.GetEnumerator();
		}
	}
