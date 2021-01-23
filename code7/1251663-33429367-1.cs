    static void Main(string[] args)
    {
    	try
    	{
    		var timeout = new CancellationTokenSource(TimeSpan.FromMilliseconds(100));
    		LongRunningTask(timeout.Token).Wait();
    	}
    	catch (AggregateException error)
    	{
    		//  handling timeout is logically okay, but expect nothing to be leaked
    	}
    	Console.WriteLine("Leaked Instances = {0}", DisposableResource.Instances);
    	Console.ReadLine();
    }
    
    static async Task LongRunningTask(CancellationToken token)
    {
    
    	using (var resource = new DisposableResource())
    	{
    		await Task.Run(async () => await Task.Delay(1000, token), token);
    	}
    }
    
    public class DisposableResource : IDisposable
    {
    	public static int Instances = 0;
    	public DisposableResource()
    	{
    		Instances++;
    	}
    
    	public void Dispose()
    	{
    		Instances--;
    	}
    }
