    public class Root
    {
         public People People { get; set; }
         public Root() { People = new People(); }
    }
    public class People
    {
         public Dictionary<string, string> Data { get; set; }
         public People() { Data = new Dictionary<string, string>(); }
    }
