    static IEnumerable<Item> Parse(string source)
	{
		var root = new Item() { Name = "Root", Children = new List<Item>() };
		AddChildrenTo(root, source);
		return root.Children;
	}
	static int AddChildrenTo(Item item, string source)
	{
		Item node = null;
		var word = new List<char>();
		for (int i = 0; i < source.Length; i++)
		{
			var c = source[i];
			if (new[] { ',', '(', ')' }.Contains(c))
			{
				if (word.Count > 0)
				{
					node = new Item { Name = new string(word.ToArray()), Children = new List<Item>() };
					(item.Children as List<Item>).Add(node);
					word.Clear();
				}
				if (c == '(')
				{
					i += AddChildrenTo(node, source.Substring(i + 1)) + 1;
				}
				else if (c == ')')
				{
					return i;
				}
			}
			else if (char.IsLetter(c)) // add other valid characters to if condition 
			{
				word.Add(c);
			}
		}
		return source.Length;
	}
