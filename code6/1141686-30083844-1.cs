	public static void Main()
	{
		var y = new Base2(); // Base2 overrides DeepClone
		Base b = y.DeepClone();
		Base2 c = y.DeepClone(); // Compiles an works
	}
