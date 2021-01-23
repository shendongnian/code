    void Main()
    {
    	TryCatch();
    	TryCatchAsync();
    }
    void TryCatch()
    {
    	try
    	{
    		ThrowAnError().Wait();
    	}
    	catch(Exception ex)
    	{
            //AggregateException
    		Console.WriteLine(ex);
    	}
    }
    async Task TryCatchAsync()
    {
    	try
    	{
    		await ThrowAnError();
    	}
    	catch(Exception ex)
    	{
            //MyException
    		Console.WriteLine(ex);
    	}
    }
    async Task ThrowAnError()
    {
    	await Task.Yield();
    	throw new MyException();
    }
    public class MyException:Exception{};
