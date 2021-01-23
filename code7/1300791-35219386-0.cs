    [Export(typeof(ISomeService))]
    public class SomeService : ISomeService {
    }
    public class SomeClass {
       [Import]
       public ISomeService SomeService {get; set;}
       [Import]
       public IAnotherService AnotherService {get; set;}
    }
