    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            double? foo = 5.0;
            double? bar = 4.0;
            double? result = foo/bar;
            Console.WriteLine("x/y: " + prettynulls(result));
            
            foo = null;
            bar = 4.0;
            result = foo/bar;
            Console.WriteLine("null/y: " + prettynulls(result));
    
            foo = 5.0;
            bar = null;
            result = foo/bar;
            Console.WriteLine("x/null: " + prettynulls(result));
   
            foo = null;
            bar = null;
            result = foo/bar;
            Console.WriteLine("null/null: " + prettynulls(result));
        }
        
        private static string prettynulls(double? val)
        {
            return val == null ? "(null)" : val.ToString();
        }
    }
