Create a wrapping method that directly call your Test method.
	public void WrapTest(object sender, EventArgs e)
	{
		Test();
	}
	public void Test()
	{
		...
	}
