    public class RootObject
    {
    	public string Sex { get; set; }
    	public string category { get; set; }
    	public int ID { get; set; }
    	public string created { get; set; }
    	public string Tag { get; set; }
    	public List<Member> members { get; set; }
    
    	public override string ToString()
    	{
    		var values = new List<string>();
    		foreach (var property in GetType().GetProperties())
    		{
    			values.Add(property.Name + ": " + property.GetValue(this));
    		}
    		return string.Join(", ", values);
    	}
    }
