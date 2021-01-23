	public class ServerResponseObject<T>
	{
		public ServerResponseObject(T obj)
		{
			this.obj = obj;
		}
		
		public T obj { get; set; }
	}
