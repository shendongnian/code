    public class MyClass
    {
            public IEnumerable<string> Values { get; set; }
    }
 
    var myEvent = new MyClass
    {
        Values = new List<string>(),
    };
