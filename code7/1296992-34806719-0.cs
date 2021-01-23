    List<dynamic> test = new List<dynamic> { new TestModel { Name = "Foo" }, new TestModel { Name = "Bar" } };
    
    var names = test.Select(x => x.Name);
    public class TestModel
    {
       public string Name { get; set; }
    }
