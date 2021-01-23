    void Main()
    {
	    string text = "NiNaCiKi";
    	Regex reg = new Regex("[A-Z]{1}[a-z]*");
	    var props = reg.Matches(text).Cast<Match>().Select(m=>m.Value).ToList();
	
     	Chem ch = new Chem();
	
	    var sum = typeof(Chem)
	    .GetProperties()
	    .Where(p=>props.Contains(p.Name))
	    .Cast<PropertyInfo>()
	    .Select(val=> (double)val.GetValue(ch)).Sum();
	
	    Console.WriteLine(sum);
    }
    public class Chem
    {
	    public double Na {get {return 4;}}
	    public double N {get {return 2;}}
	    public double Ci {get {return 1;}}
    }
