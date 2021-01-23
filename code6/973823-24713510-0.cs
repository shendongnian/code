    void Main()
    {
    	//create test list
    	var fooService = new List<Foo>();
    	var random = new Random();
    	Enumerable.Range(0,30).ToList().ForEach(i => fooService.Add(new Foo(){Id=i,Type=(FooType)random.Next(0,3),FooName="Foo"+i}));
    	
    	//select view models
    	fooService.Select(x => new FooVM
                 {
                   FooName = x.FooName,
                   Type = x.Type
                  }
            ).Dump();
    }
    
    public enum FooType
    {
      Red,
      Green,
      Blue
    }
    
    public class Foo
    {
      public int Id { get; set; }
      public FooType Type { get; set; }
      public string FooName { get; set; }
    }
    
    public class FooVM
    {
      public FooType Type { get; set; }
      public string FooName { get; set; }
    }
