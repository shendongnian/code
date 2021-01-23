	void FirstMethod()
	{
		int a = 0;
		int b = 10;
		int c = b / a;
	}
	void SecondMethod()
	{
		FirstMethod();
	}
	void ThirdMethod()
	{
		SecondMethod();
	}
	void FourthMethod()
	{
		try
		{
			ThirdMethod();
		}
		catch (DivideByZeroException ex)
		{
			// Handle error
		} 
	}
