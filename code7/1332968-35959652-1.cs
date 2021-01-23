    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
    	public static string A = "A";
    	public static string B = "B";
    	public static string C = "C";
    	public static string NULL = "null";
    	
    	public static void Main()
    	{	
    		var lo = new LO();
    		lo.Add(new OB{A});
    		lo.Add(new OB{B});
    		lo.DisplayResult();
    
    		lo.Clear();
    		lo.Add(new OB{A});
    		lo.Add(new OB{NULL});
    		lo.Add(new OB{B});
    		lo.DisplayResult();
    
    		lo.Clear();
    		lo.Add(new OB{A});
    		lo.Add(new OB{NULL});
    		lo.Add(new OB{NULL});
    		lo.Add(new OB{NULL});
    		lo.Add(new OB{NULL});
    		lo.Add(new OB{B});
    		lo.DisplayResult();
     
    		lo.Clear();
    		lo.Add(new OB{A});
    		lo.Add(new OB{A,B});
    		lo.Add(new OB{B});
    		lo.DisplayResult();
    
    		lo.Clear();
    		lo.Add(new OB{A});
    		lo.Add(new OB{NULL});
    		lo.Add(new OB{A});
    		lo.DisplayResult();
    
    		lo.Clear();
    		lo.Add(new OB{A});
    		lo.Add(new OB{A,B});
    		lo.Add(new OB{A});
    		lo.DisplayResult("Why is this not a transition but an exception?");
    
    
    		lo.Clear();
    		lo.Add(new OB{A});
    		lo.Add(new OB{A,NULL});
    		lo.Add(new OB{A,NULL,NULL});
    		lo.Add(new OB{A});
    		lo.DisplayResult("<A,NULL> and <A,NULL,NULL> are considered equal as per your second comment.");
    
    		lo.Clear();
    		lo.Add(new OB{A});
    		lo.Add(new OB{A,B,NULL,C});
    		lo.Add(new OB{A});
    		lo.DisplayResult("As per your first comment");
    
    		lo.Clear();
    		lo.Add(new OB{A});
    		lo.Add(new OB{A,B});
    		lo.Add(new OB{B,A});
    		lo.Add(new OB{A});
    		lo.DisplayResult("Second and third OB are equal as per your first comment");
    
    		lo.Clear();
    		lo.Add(new OB{A});
    		lo.Add(new OB{NULL,A});
    		lo.Add(new OB{B});
    		lo.DisplayResult();
		    lo.Clear();
		    lo.Add(new OB{A});
		    lo.Add(new OB{A,B,C});
	    	lo.Add(new OB{B});
    		lo.DisplayResult("Why is this not a transition as per your fourth comment?");
    	}
    }
    
    // list of objects (LO) = list<OB>
    public class LO : List<OB>
    {
    	public void DisplayResult(string message = null)
    	{
    		Console.WriteLine("{0} : {1}",this,CountTransitions());
            if(message != null)
    		{
    			Console.WriteLine(message);
    		}
    		Console.WriteLine();
    	}
    
    	private int CountTransitions()
    	{
    		if(this.Any()== false || this.Count == 1) return 0;
    		
    		var first = this.FirstOrDefault();
    		var last = this.LastOrDefault();
    		
    		// first OB and last OB must have exactly one element.
    		if(first.Count != 1 || last.Count != 1) return 0;
    				
    		var transitions = 0;
    		for(var i = 0; i < this.Count - 1; i++)
    		{
    			// when current OB and next OB are not the same, it is a transition
    			transitions = IsTransition(this[i],this[i+1]) ? transitions + 1 : transitions;
    		}
    		return transitions;
    	}
    	
    	private bool IsTransition(OB lhs, OB rhs)
    	{
    		var lhsSet = new SortedSet<String>(lhs);
    		var rhsSet = new SortedSet<String>(rhs);
    	    return lhsSet.SetEquals(rhsSet) == false;
    	}
    
    	public override string ToString()
    	{
    		return String.Join(" -> ", this.Select(x => x.ToString()));
    	}
    }
    
    // objects (OB) = list<int?>
    public class OB : List<String>
    {
    	public override String ToString()
    	{
    		return String.Format("[{0}]", String.Join(",", this));
    	}
    }
