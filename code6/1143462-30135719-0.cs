    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
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
        public delegate void DoSomethingUseful();   // same as Action delegate
    
        class Program
        {
            /// <summary>
            /// create delegate
            /// </summary>
            /// <param name="namespace"> namespace name </param>
            /// <param name="class"> class name </param>
            /// <param name="method"> method name </param>
            /// <returns></returns>
            public static DoSomethingUseful GetDelegate(string @namespace, string @class, string method)
            {
                // common argument checks
                if (@namespace == null) throw new ArgumentNullException("namespace");
                if (@class == null) throw new ArgumentNullException("class");
                if (method == null) throw new ArgumentNullException("method");
    
                // find class
                Type type = Type.GetType(@namespace + "." + @class);
                if (type == null) throw new Exception("type not found");
    
                // find method
                MethodInfo methodInfo = type.GetMethod(method);
                if (methodInfo == null) throw new Exception("method not found");
    
                // create the delegate
                return (DoSomethingUseful)Delegate.CreateDelegate(typeof(DoSomethingUseful), methodInfo.IsStatic ? null : Activator.CreateInstance(type), methodInfo);
            }
    
            static void Main(string[] args)
            {
                // creating delegates
                DoSomethingUseful methodA = GetDelegate("NamespaceA", "ClassAB", "MyMethod");
                DoSomethingUseful methodB = GetDelegate("NamespaceA", "ClassAB", "MyStaticMethod");
    
                // usage
                methodA();
                methodB();
    
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
