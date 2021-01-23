		class Base
		{
			// "private" so it's NOT accessible by derived class
			private Base() { } // no parameters - aka parameterless
		
			// "protected" so it's accessible by derived class
			protected Base(int a) { } // has parameter - aka NOT parameterless
		}
		
		class Derived : Base
		{
			// OK - Explicitly calling accessible base constructor with `int` parameter
			public Derived() 
                : base(10) 
                { }
		}
