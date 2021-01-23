	MakeAndProcess(c => {
	    // write code that uses C here.
        // This will work, because A and B are not disposed yet.
	});
	public void MakeAndProcess(Action<C> processC)
	{
		using (var a = new A())
		using (var b = new B(a))
		{
			processC(new C(b));
		}
	}
