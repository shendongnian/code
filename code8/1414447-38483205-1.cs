		class Base {
			// "protected" so it's accessible by derived class
			protected Base() { } // no parameters - aka parameterless
		}
		
		class Derived : Base {
			// OK - implicitly calls accessible parameterless constructor base()
			public Derived() {}
		}
