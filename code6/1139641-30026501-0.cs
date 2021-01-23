    // Your method
	public static void Method1(ref List<int> list)
	{
	}
    // The delegate
	public delegate void Method1Delegate(ref List<int> list);
    // A method that accepts the delegate and uses it
	public static void Method2(Method1Delegate del)
	{
		List<int> list = null;
		del(ref list);
	}
