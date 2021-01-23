    public static void StartNewLogFile()
	{
		Hierarchy hierachy = (Hierarchy)log4net.LogManager.GetRepository();
		Logger logger = hierachy.Root;
		var rootAppender = logger.Appenders.OfType<FileAppender>().FirstOrDefault();
		string filename = rootAppender != null ? rootAppender.File : string.Empty;
		while (logger != null)
		{
			foreach (IAppender appender in logger.Appenders)
			{
				FileAppender fileAppender = appender as FileAppender;
				if (fileAppender != null)
				{
					fileAppender.File = filename + "a";
					fileAppender.File = filename;
					fileAppender.ActivateOptions();
				}
			}
			logger = logger.Parent;
		}
		File.Delete(filename + "a");
	}
	
