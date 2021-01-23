    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using TestConsole.Data;
    
    namespace NamespaceA
    {
        public class ClassAB
        {
            public void MyMethod()
            {
                Console.WriteLine("You invoke NamespaceA.ClassAB.MyMethod");
            }
    
            public static void MyStaticMethod()
            {
                Console.WriteLine("You invoke NamespaceA.ClassAB.MyStaticMethod");
            }
        }
    }
    
    namespace TestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                Type type = Type.GetType("NamespaceA.ClassAB");
                object instance = Activator.CreateInstance(type);
                type.GetMethod("MyMethod").Invoke(instance, null);      // instance is required
                type.GetMethod("MyStaticMethod").Invoke(null, null);    // instance is not required
    
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
