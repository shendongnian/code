    static void Main(string[] args)
    {
    	try {
                var timeout = new CancellationTokenSource(TimeSpan.FromMilliseconds(100));
                LongRunningTask().Wait(timeout.Token);
            } catch (OperationCanceledException error) {                
                //  handling timeout is logically okay, but expect nothing to be leaked
            }
    		
        Console.WriteLine("Leaked Instances = {0}", DisposableResource.Instances);
    	
    	Console.ReadKey();
    }
    
    static async Task LongRunningTask()
    {
    	using (var resource = new DisposableResource())
    	{
    		await Task.Run(() => Thread.Sleep(1000));
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
    		Console.WriteLine("Disposed resource. Leaked Instances = {0}", Instances);
    	}
    }
    
