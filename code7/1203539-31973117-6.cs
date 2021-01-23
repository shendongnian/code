    void Main()
    {
    	var x = new List<Test>();
    	
    	x.Add(new Test{ Number = "one" });
    	x.Add(new Test{ Number = "two" });
    	x.Add(new Test{ Number = "three", IsDeleted = true });
    	
    	var y = x.WhereNotDeleted(a => a != null);
    	y.Count().Dump();
    }
    public class Test : IDeletable
    {
    	public string Number { get; set; }
    	public bool IsDeleted { get; set; }
    }
