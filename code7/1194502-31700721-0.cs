    public class CUT
    {
    	private B _b;
    
    	public CUT(B b)
    	{
    		_b = b;
    	}
    }
	[TestMethod]
	public void test01()
	{
		// Arrange
        // here you create your fake-array
		A[] bazFake = new A[] { new A { Foo = 1, Bar = 2 } };
		B bFake = new B();
		bFake.Baz = bazFake;
        // and inject this fake-object into the CUT
		CUT cut = new CUT(bFake);
		// Act
		// ...
		// Assert
		// ...
	}
