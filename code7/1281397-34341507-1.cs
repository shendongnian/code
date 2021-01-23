		internal class MyClass : BaseClass
		{
			private object _createCB;
			
			public delegate T Create<T>(int identity) where T : SomeOtherClass;
			
			public Create<T> GetCreateCB<T>()
			{
				return (Create<T>)_createCB;
			}
			
			public void SetCreateCB<T>(Create<T> fn)
			{
				_createCB = fn;
			}
		}
		
	Hopefully this snippet shows why there's no such thing as a generic property in the first place. You loose the strong typing anyway because of the storage. And you have to provide `T` explicitly on each get/set - you'd better be coherent with that.
