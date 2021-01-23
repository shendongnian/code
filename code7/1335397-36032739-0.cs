	public class EnumerableObject<T> : IEnumerable<T>
	{
		public IEnumerator<T> GetEnumerator()
		{
			// Implement.
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
