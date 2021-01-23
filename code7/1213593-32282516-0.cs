    using System.Linq;
    void Main()
    {
    	double[] chevy = { 1, 2, 1, 1 };
    	double[] ford = { 2, 1, 1, 2 };
    
    	var results = chevy.Zip(ford, (c, f) => 
    	{
    		if(c < f)
    		{
    			return "Chevy Won";
    		}
    		else if(f < c)
    		{
    			return "Ford Won";
    		}
    		else
    		{
    			return "It was a tie";
    		}
    	});
    	
    	results.Dump();
    }
    //output
        Chevy Won 
        Ford Won 
        It was a tie 
        Chevy Won 
