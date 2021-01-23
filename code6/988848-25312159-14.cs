    // ErrorLogModule.LogException
	try
	{
		Error error = new Error(e, context);
		ErrorLog errorLog = this.GetErrorLog(context);
		error.ApplicationName = errorLog.ApplicationName;
		string id = errorLog.Log(error);
		errorLogEntry = new ErrorLogEntry(errorLog, id, error);
	}
	catch (Exception value)
	{
		Trace.WriteLine(value);
	}
