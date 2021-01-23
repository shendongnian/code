    void Main()
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer(new SimpleTypeResolver());
        var original = new Container()
        {
            List = new List<A> { new A(), new B(), new C() }
        };
        var json = serializer.Serialize(original);
        var deserialized = serializer.Deserialize<Container>(json);
        Console.WriteLine(deserialized.List[0].GetType() == typeof(A)); // true
        Console.WriteLine(deserialized.List[1].GetType() == typeof(B)); // true
        Console.WriteLine(deserialized.List[2].GetType() == typeof(C)); // true
    }
    public class Container
    {
        public IList<A> List
        { get; set; }
    }
    public class A
    { }
    public class B : A
    { }
    public class C : A
    { }
