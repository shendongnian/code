	public class Boxer<T, U> : ICovariant<T> where U : struct, T
	{
		public Boxer( ICovariant<U> foo )
		{
			mFoo = foo;
		}
	
		public Func<T> CallMe => () => mFoo.CallMe();
		
		private readonly ICovariant<U> mFoo;
	}
