	public static void Shuffle<T>(this Stack<T> stack)
	{
		var values = stack.ToArray();
		stack.Clear();
		foreach (var value in values.OrderBy(x => rnd.Next()))
			stack.Push(value);
	}
