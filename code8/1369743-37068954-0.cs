    using System;
    
    public class Test
    {
        static void Main()
        {
            // Declaring as object to avoid using the == overload in string
            object x = CreateString(new char[0]);
            object y = CreateString(new char[0]);
            object z = CreateString(new char[1]);
            Console.WriteLine(x == y); // True
            Console.WriteLine(x == z); // False        
        }
        
        static string CreateString(char[] c)
        {
            return new string(c);
        }
    }
