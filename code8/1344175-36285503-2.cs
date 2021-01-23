    try
    {
        //...
    }
    catch (Exception ex)
    {
			// Asynchronously log the error message in a helper class using NLog
			LogHelper.LogException(ex, "Error calculating blah.", LogLevel.Error);
			throw new FaultException<MyFaultException>(
					new MyFaultException(ex.Message), new FaultReason(ex.Message));
	}
