    // SEALED
    public sealed class A 
    {
         private static readonly A _instance;
    
         // Avoid that other code excepting A class members
         // can instantiate A
         private A() {}
         static A() 
         {
             _instance = new A();
         }
         public static A Instance => _instance;
         
         public string Name { get; set; }
    }
