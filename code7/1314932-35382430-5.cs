    public class Foo
    {
    	public ICollection<Bar> Bars { get; set; }
    }
    
    public class Bar
    {
    	public ICollection<Baz> Bazs { get; set; }
    }
    
    public class Baz
    {
    	public ICollection<Detail> Details { get; set; }
    }
    
    public class Detail
    {
    	public int Amount { get; set; }
    }
