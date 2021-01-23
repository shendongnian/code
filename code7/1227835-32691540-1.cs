	public class ServerResponseObject<T>
	{
		public ServerResponseObject(T obj)
		{
			Obj = obj;
		}
		
		public T Obj { get; set; }
	}
