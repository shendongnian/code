		WCFServiceClient c = new WCFServiceClient();
		try
		{
				c.HelloWorld();
		}
		catch
		{
				c.Abort();
				throw;
		}
		finally
		{
				c.Close();
		}
