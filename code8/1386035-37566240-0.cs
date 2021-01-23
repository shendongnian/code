     public class Test1FooCom
       {
          public string name { get; set; }
          public string customerNumber { get; set; }
       }
    var obj = new Dictionary<string, Test1FooCom>
       {
        {"test1@foo.com", new Test1FooCom(){name="Foo Bar 1",customerNumber="1234"}},
        {"test2@foo.com", new Test1FooCom(){name="Foo Bar 2",customerNumber="9876"}},        
       };
    
       var json = JsonConvert.SerializeObject(obj);
