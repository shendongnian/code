		class Base {
			// "private" so it's NOT accessible by derived class
			private Base() { } // no parameters - aka parameterless
		
			// "protected" so it's accessible by derived class
			protected Base(int a) { } // has parameter - aka NOT parameterless
		}
		
		class Derived : Base {
			// FAIL - STILL tries to implicitly call parameterless constructor base()
			// ERROR CS0122 - Base.Base() is inaccessible due to it's protection level
			public Derived() { } 
		}
