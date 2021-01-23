	void Main()
	{
		var list = new LinkedList<int>();
		list.InsertValue(5);
		list.InsertValue(2);
		list.InsertValue(3);
		
		for (var c = list.root; c != null; c = c.link)
			Console.WriteLine(c.value);
	}
