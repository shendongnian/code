	public class Wrapper<TClient>
	{
		public TResult Invoke<TArg, TResult>(Func<TArg, TResult> action, TArg arg)
		{
			return action(arg);
		}
	}
