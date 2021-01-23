	try
	{
        //your code here
		//throw new IOException("Generic IO Exception caught"); //test generic IOException
        //throw new PipeException("Pipe Exception caught"); //test specific PipeException
	}
	catch (PipeException e)
	{
		Console.WriteLine("Pipe Exception: {0}", e.Message); //swallow this however you like
	}
	catch (IOException e)
	{
		Console.WriteLine("Generic IOException: {0}", e.Message); //handle generics here
	}
	catch (Exception e)
	{
		Console.WriteLine("Generic Exception: {0}", e.Message); //non IO exceptions
	}
	finally
	{
		//cleanup
	}
