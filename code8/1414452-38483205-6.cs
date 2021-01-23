		class Base
		{
		    // No constructor explicitly defined so a default constructor is assumed
			// Having no constructor at all is like having an empty constructor
			// Like this: Base() { }
		}
		
		class Derived : Base
		{
			// OK - Explicitly calling accessible base constructor
			public Derived() { }
		}
