    public class ExampleClass
    {
          public foo myFooObject { get; set; }
          public bar myBarObject { get; set; }
    }
    
    select new ExampleClass { foo = something, bar = something };
