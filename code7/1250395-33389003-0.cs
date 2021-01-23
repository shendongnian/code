    void Main()
    {
    	var strings = new List<string>("2000 10003 1234000 44444444 9999 11 11 22 123".Split(' '));
    	strings.Sort(new MyComparer());
    	Console.WriteLine(String.Join(" ", strings));
    }
    
    public class MyComparer : IComparer<string>
    {
    	public int Compare(string a, string b)
    	{
    		var aWeight = GetWeight(a);
    		var bWeight = GetWeight(b);
    		if (aWeight==bWeight)
    		{
    			return String.Compare(a,b);
    		}
    		else
    		{
    			return aWeight < bWeight ? -1 : 1;
    		}
    		
    	}
    	
    	private int GetWeight(string number)
    	{
    		var weight = 0;
    		foreach(var digit in number)
    		{
    			weight+=Int32.Parse(digit.ToString());
    		}
    		return weight;
    	}
    }
