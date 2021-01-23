    void Main()
    {
    	Dictionary<Predicate<Input>, string> rules = new Dictionary<Predicate<UserQuery.Input>, string>();
    	
    	rules.Add((input) => input.A == 0 && input.B < 0.3, "output1.1");
    	rules.Add((input) => input.A == 0 && input.B < 0.7, "output1.2");
    
    	var test1Point1 = new Input
    	{
    		A = 0,
    		B = 0.2F
    	};
    
    	var test1Point2 = new Input
    	{
    		A = 0,
    		B = 0.7F
    	};
    
    	
    	rules.First(w => w.Key(test1Point1)).Value.Dump(); //outputs output1.1
    	rules.First(w => w.Key(test1Point2)).Value.Dump(); //outputs output1.2
    
    }
    
    // Define other methods and classes here
    public struct Input
    {
    	public int A;
    	public float B;
    }
