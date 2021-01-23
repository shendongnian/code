		internal class MyClass<T> : BaseClass
			where T : SomeOtherClass
		{
			public delegate T Create(int identity);
			
			// Now T is in scope
			public Create CreateCB { get; set; }
		}
		
