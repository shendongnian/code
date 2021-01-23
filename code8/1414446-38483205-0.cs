		class Base {
			// "public" so it's accessible by derived class
			public Base() { } // no parameters - aka parameterless
		}
		
		class Derived : Base {
			// OK - implicitly calls accessible parameterless constructor base()
			public Derived() {}
		}
