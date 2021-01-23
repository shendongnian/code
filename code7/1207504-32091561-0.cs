    using System;
    using System.Reflection;
    using System.Collections.Generic;
    
    public class A<T1, T2> { }
    
    public class B<T> : A<T, int> { }
    
    class Program
    {
        static void Main()
        {
            var bT = typeof(B<>).GetTypeInfo().GenericTypeParameters[0];
            var listT = typeof(List<>).GetTypeInfo().GenericTypeParameters[0];
            var bBaseArguments = typeof(B<>).BaseType.GenericTypeArguments;
            Console.WriteLine(bBaseArguments[0] == bT); // True
            // Shows that the T from B<T> isn't the same as the T from List<T>
            Console.WriteLine(bBaseArguments[0] == listT); // False
            Console.WriteLine(bBaseArguments[1] == typeof(int)); // True
        }
    }
