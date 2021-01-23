    public sealed class A 
    {
         private static readonly A _instance = new A();
         public static A Instance => _instance;
         public string Name { get; set; }
    }
