    class Entity
    {
    	public ICollection<SubEntity> SubEntity { get; set; }
    }
    
    class SubEntity
    {
    	public bool SomeProperty { get; set; }
    	public SubSubEntity SubSubEntity { get; set; }
    }
    
    class SubSubEntity
    {
    	public string FooProperty { get; set; }
    	public string BarProperty { get; set; }
    	public ICollection<SubSubSubEntity> SubSubSubEntity { get; set; }
    }
    
    class SubSubSubEntity
    {
    	public SubSubSubSubEntity SubSubSubSubEntity { get; set; }
    }
    
    class SubSubSubSubEntity
    {
    	public string BazProperty { get; set; }
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		string comparisonProperty = "Ivan";
    		Expression<Func<Entity, bool>> e =
    			entity => entity.SubEntity.Any(subEntity =>
    				subEntity.SomeProperty == false
    				&&
    				subEntity.SubSubEntity.FooProperty.StartsWith(comparisonProperty)
    				&&
    				subEntity.SubSubEntity.BarProperty == "Bar"
    				&&
    				subEntity.SubSubEntity.SubSubSubEntity.Any(subSubSubEntity => subSubSubEntity.SubSubSubSubEntity.BazProperty == "whatever")
    				);
    		var v = new TestVisitor();
    		v.Visit(e);
    		var result = v.Result;
    	}
    }
