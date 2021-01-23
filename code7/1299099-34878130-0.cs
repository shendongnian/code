	public abstract class CubeClient<T1, T2>
		where T1 : CubeClient<T1, T2>
		where T2 : CubeConnection<T1, T2>
	{
	}
	
	public abstract class CubeConnection<T1, T2>
		where T1 : CubeClient<T1, T2>
		where T2 : CubeConnection<T1, T2>
	{
	}
