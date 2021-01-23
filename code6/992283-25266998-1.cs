    using System;
    using System.Reflection;
    namespace Test081204
    {
        [AttributeUsage(AttributeTargets.Parameter)]
        public class SomeCoolAttribute : System.Attribute
        {
            public readonly int Val;
            public SomeCoolAttribute(int val)
            {
                Val = val;
            }
        }
        class Test
        {
            public void Run([SomeCool(123)] string value)
            {
                // Prints "In Run: test123"
                Console.WriteLine("In Run: " + value);
            }
        }
        class Program
        {
            public static void Main()
            {
                var parameters = typeof(Test).GetMethod("Run").GetParameters();
                var attr = parameters[0].GetCustomAttribute(typeof(SomeCoolAttribute)) as SomeCoolAttribute;
                // Prints "123"
                Console.WriteLine("In Main: " + attr.Val);
                new Test().Run("test" + attr.Val.ToString());
            }
        }
    }
