	void ThirdMethod()
	{
		try
		{
			SecondMethod();
		}
		catch (Exception ex)
		{
			// Log the error
			throw; // Throw exception without affecting StackTrace
		}	
	}
