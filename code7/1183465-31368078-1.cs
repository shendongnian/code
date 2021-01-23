    void Main()
    {
    	string s = "hello";
    	M(s);
    	Console.WriteLine(s);
    	M(ref s);
    	Console.WriteLine(s);
    }
    
    public void M(string s)
    {
    	s = "this won't change the original string";
    }
    
    public void M(ref string s)
    {
    	s = "this will change the original string";
    }
