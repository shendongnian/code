	class ROList<T>
	{
		public ROList(IEnumerable<T> argEnumerable)
		{
			m_list = new List<T>(argEnumerable);
		}
		private readonly List<T> m_list;
		public IReadOnlyList<T> List { get { return m_list;	} }
	}
	void Main()
	{
		var list = new	List<int> {1, 2, 3};
		var rolist = new ROList<int>(list);
		
		foreach(var i in rolist.List)
			Console.WriteLine(i);
		
		//rolist.List.Add(4); // Uncomment this and it won't compile: Add() is not allowed
	}
