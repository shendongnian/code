    class Base 
    {
        public Base() {
            Console.WriteLine("BaseClass Const.");
        }
    }    
    
    class Derived : Base
    {
        public Derived() { }   
        public Derived(params object[] args) : base() { } 
    }
        
        public class Program
        {
            public static void Main(string[] args)
            {
                
                Derived d = new Derived(null) ;
                 
            }
        }
