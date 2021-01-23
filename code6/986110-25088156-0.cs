    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Classname.staticmethod();
    
                Classname name = new Classname();
                Console.ReadLine();
            }
        }
        public class Classname
        {
            public static void staticmethod()
            {
                Console.WriteLine("staticmethod called");
            }
    
            static Classname()
            {
                Console.WriteLine("Static Constructor called");
            }
    
            public Classname()
            {
                Console.WriteLine("Instance Constructor called");
            }
        }
    }
