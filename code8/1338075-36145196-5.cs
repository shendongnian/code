    using System;
    using System.Reflection;
    namespace ConsoleApplication
    {
        public class Program
        {        
            public static void Main(string[] args)
            {
                MyDelegate myDelegate = MyDelegateInstance;
                
                Console.WriteLine("-----");
                Console.WriteLine(myDelegate.Method.Name);
                Console.WriteLine(typeof(Program).BaseType);
                Console.WriteLine("-----");
                
                Console.ReadLine();
            }
            
            private delegate string MyDelegate();
            
            private static string MyDelegateInstance() { return string.Empty; }
        }
    }
