    class BarTemp
    {
    	public string BarId { get; set; }
    	public string Foos { get; set; }
    }
    
    class Bar
    {
    	public string BarId { get; set; }
    	public ICollection<Foo> Foos { get; set; }
    }
    class Foo
    {
    	public string Id { get; set; }
    	public Bar Bar { get; set; 
    }
