	class A {
		public A () {}
	    public A (int x) {}
	}
	class B : A {
		public B(): base() {} // See <1>
	}
	var b1 = new B();  // O.K.
    var a = new A(42); // O.K.
	
    // Compiler error, as there is no matching constructor in B:
    // "'B' does not contain a constructor that takes 1 arguments"
	var b2 = new B(42);
