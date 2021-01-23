    using System;
    
    public class C {
        public virtual void M() {
            Console.WriteLine("Inside the method M. this == null: {0}", this == null);
        }
    }
    
    public class Program {
        public static void Main(string[] pars)
        {
            C obj = null;
            obj.M();
        }
    }
