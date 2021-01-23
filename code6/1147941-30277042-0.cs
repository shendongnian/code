    class Reeks : IEnumerable<int>
	{
		private int i = 1;
		public Reeks() {  }
	
		public IEnumerator<int> GetEnumerator()
		{
			while (true)
			{
				i = i * 2;
				yield return i;
			}
		}
	
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
