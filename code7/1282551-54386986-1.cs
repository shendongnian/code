    public class Foo
    {
    	public string Key { get; set; }
    }
    
    // #1
    var foo = new Foo { Key = "value" };
    
    // #2
    var foos = new List<Foo>();
    foos.Add(foo);
    
    // #3
    var lst = new List<object>();
    lst.Add(new { Name = "John" });
    
    IsList(foo); // false
    IsList(foos); // true
    IsList(lst); // true
