    using System;
    using System.Reflection;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            public delegate string MyDelegate();
            
            public static void Main(string[] args)
            {
                MyDelegate myDelegate = () => string.Empty;
                var methodInfo = myDelegate.Method;
                
                Console.WriteLine(methodInfo.Name);
            }
        }
    }
