    [Flags]
    public enum Test
    {
    	A = 1,
    	B = 2,
    	C = 4
    }
    
    Test t;
	Enum.TryParse<Test>("A,B", out t);
