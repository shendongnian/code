	if (errors.Any())
	{
		if (errors.Count > 1)
		{
			throw new AggregateException("Multiple errors. See InnerExceptions for more details",errors);
		}
		else
		{
			ExceptionDispatchInfo.Capture(errors[0]).Throw();
		}
	}
