    using System;
    using System.Linq;
    using System.Reflection;
    public class Program
    {
        static void Main(string[] args)
        {
        }
    }
    
    public class Test
    {
        static Test()
        {
            ConstructorInfo ci = typeof(Test).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static).Single();
            Console.WriteLine("Static constructor: IsPublic: {0}, IsPrivate: {1}", ci.IsPublic, ci.IsPrivate);
        }
    }
