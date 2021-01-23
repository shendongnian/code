    void Main()
    {
    	List<RuleResultPair> rules = new List<RuleResultPair>();
    
    	rules.Add(new RuleResultPair 
    	{
    		Rule = (input) => input.A == 0 && input.B < 0.3, 
    		Result = "output1.1"
    	});
    
    	rules.Add(new RuleResultPair
    	{
    		Rule = (input) => input.A == 0 && input.B < 0.7,
    		Result = "output1.2"
    	});
    
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
    
    	
    	rules.First(w => w.Rule(test1Point1)).Result.Dump(); //outputs output1.1
    	rules.First(w => w.Rule(test1Point2)).Result.Dump(); //outputs output1.2
    
    }
    
    // Define other methods and classes here
    public struct Input
    {
    	public int A;
    	public float B;
    }
    
    public class RuleResultPair
    {
    	public Predicate<Input> Rule;
    	public string Result;
    }
