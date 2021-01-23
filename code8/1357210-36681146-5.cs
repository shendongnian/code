    // SEALED
    public sealed class A 
    {
         private readonly A _current;
    
         static A() 
         {
             _current = new A();
         }
         public static A Current => _current;
         
         public string Name { get; set; }
    }
