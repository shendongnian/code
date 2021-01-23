	MakeAndProcess(c => {
	    // write code that uses C here.
	});
	public void MakeAndProcess(Action<C> processC)
	{
		using (var a = new A())
		using (var b = new B(a))
		{
			processC(new C(b));
		}
	}
