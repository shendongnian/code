	try
	{
		RunSensitiveMethod();
	}
	catch (SecurityTokenValidationException e)
	{
		// Perhaps something fancier if needed.
		logger.Log(e);
		throw new MyCustomException("We screwed up!");
	}
