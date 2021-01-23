	public static string Log(string code, string message)
	{
		string log;
		using (var writer = File.AppendText(FilePath))
		{
			log = ("\r\n" + code + ": \n");
			log += String.Format("{0} {1}\n", DateTime.Now.ToLongTimeString(),
				DateTime.Now.ToLongDateString());
			log += String.Format("  :{0}\n", message);
			log += String.Format("-------------------------------");
			writer.WriteLine(log);
		}
		return log;
	}
