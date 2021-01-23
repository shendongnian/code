	using System.Collections.Generic;
	public struct Index1
	{
		public int Value { get; set; }
	}
	public class Index1List<T>
	{
		private List<T> _inner = new List<T>();
		public T this[Index1 index]
		{
			get { return _inner[index.Value]; }
			set { _inner[index.Value] = value; }
		}
		// Other desired IList<T> methods.
	}
	public struct Index2
	{
		public int Value { get; set; }
	}
	public class Index2List<T>
	{
		private List<T> _inner = new List<T>();
		public T this[Index2 index]
		{
			get { return _inner[index.Value]; }
			set { _inner[index.Value] = value; }
		}
		// Other desired IList<T> methods.
	}
