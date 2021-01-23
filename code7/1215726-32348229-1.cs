    public class Property
	{
    	public string Name { get; set; }
    	public string Type { get; set; }
    	public string Value { get; set; }
    	public Property()
    	{}
    	public Property(string n, string t, string v)
    	{
    		this.Name = n;	
    		this.Type = t;
    		this.Value = v;
    	}
	}
