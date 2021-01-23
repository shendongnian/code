    void Main()
    {
    	var test = Add(() => 5)(6);
    	test.Dump();
    }
    
    public Func<int, int> Add(Func<int> a)
    {
    	return (x) => x + a();
    }
    
    //returns 11
