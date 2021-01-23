	void Main()
	{
		try
		{
			throw new SftpException(1, "hello");
		}
		catch (SftpException e)
		{
			Console.WriteLine(e.message);
		}
	}
	
