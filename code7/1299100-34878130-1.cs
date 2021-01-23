	public class FooClient : CubeClient<FooClient, BarConnection>
	{
	}
	
	public class BarConnection : CubeConnection<FooClient, BarConnection>
	{
	}
