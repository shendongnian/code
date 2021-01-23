	public class Wrapper<TClient>
	{
		public Wrapper(TClient client)
		{
			this.Client = client;
		}
		
		private TClient Client;
		
		public TResult Invoke<TArg, TResult>(Func<TClient, TArg, TResult> action, TArg arg)
		{
            if (operation.Target != Client)
              throw new ArgumentException(nameof(operation));
			return action(this.Client, arg);
		}
	}
	
