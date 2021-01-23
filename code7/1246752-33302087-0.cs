	try
	{
		OracleConnection con;
		con = new OracleConnection();
		con.ConnectionString = "DATA SOURCE=<DSOURCE_NAME>;PERSIST SECURITY INFO=True;USER ID=******;PASSWORD=*******";
		con.Open();
	}
	catch (OracleException ex)
    {
    	Console.WriteLine("Oracle Exception Message");
		Console.WriteLine("Exception Message: " + ex.Message);
		Console.WriteLine("Exception Source: " + ex.Source);
    }
    catch (Exception ex)
    {
    	Console.WriteLine("Exception Message");
		Console.WriteLine("Exception Message: " + ex.Message);
		Console.WriteLine("Exception Source: " + ex.Source);
    }
