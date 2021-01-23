    public class A 
    {
         private static readonly A _instance;
    
         static A() 
         {
             _instance = new A();
         }
         public static A Instance => _instance;
         
         public string Name { get; set; }
    }
