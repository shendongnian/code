	try
	{
		foreach (var str in strlist)
		{
			var jsonData = str;
			File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)+
							  "test\"+".json", jsonData.ToString());
			savedFiles++;
		}
	}
	catch (PathTooLongException pe)
	{
		// Do Stuff
	}
	catch (Exception exception)
	{
		_log.ErrorFormat("Exception occurred in Saving JsonDocs , 
						  exception Message {0}", exception.Message);
		return savedFiles;
	}
	
