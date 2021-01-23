		class BaseWithOutMethod 
		{
			
		}
		class BaseWithMethod : BaseWithOutMethod
		{
			protected virtual void Method()
			{
				// do method stuff
			}
		}
		class Class2 : BaseWithMethod
		{
			protected override void Method()
			{
				base.Method();
			}
		}
		class Class3 : BaseWithOutMethod
		{
			public Class3()
			{
				// cannot access Method because it is not in this base class
			}
		}
