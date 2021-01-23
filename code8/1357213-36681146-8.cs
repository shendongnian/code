    public sealed class A 
    {
         private static readonly A _current = new A();
         public static A Current => _current;
         public string Name { get; set; }
    }
