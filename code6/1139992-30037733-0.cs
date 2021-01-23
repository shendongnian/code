    try
	{
		client.Send(message);
	}
	catch (SmtpException e)
	{
		Console.WriteLine("Error: {0}", e.StatusCode);
	}
 
