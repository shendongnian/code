    using System;
    using System.Reflection;
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a method name: ");
            
            // user enters a method name
            string input = Console.ReadLine();
            
            var method = typeof(Program).GetMethod(input,
                BindingFlags.Static | BindingFlags.NonPublic);
            var func = (Func<string, string>) Delegate.CreateDelegate(
                typeof(Func<string, string>), method);
            RunMethod(func);
        }
        
        static void RunMethod(Func<string, string> method)
        {
            Console.WriteLine(method("John Doe"));
        }
        
        static string Method1(string name)
        {
            return "method 1 called : " + name;
        }
        
        static string Method2(string name)
        {
            return "method 2 called : " + name;
        }
    }
