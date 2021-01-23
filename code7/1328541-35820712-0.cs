    using System;
    using System.Linq;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(Outer(1, "s"));
                Console.WriteLine(Outer("1", "s"));
                Console.ReadLine();
            }
            private static int FindInner<T>(T value)
            {
                var type = (from x in Assembly.GetAssembly(typeof(Program)).GetTypes()
                            where x.BaseType.IsGenericType && x.BaseType == typeof(IInnerManager<>).MakeGenericType(value.GetType())
                            select x).Single();
                return ((IInnerManager<T>)Activator.CreateInstance(type)).Inner(value);
            }
            public static int Outer<T1, T2>(T1 a, T2 b) { return FindInner(a) + FindInner(b); }
        }
        public abstract class IInnerManager<T> { public abstract int Inner(T t); }
        public class InnerInt : IInnerManager<int> { public override int Inner(int t) { return 1; } }
        public class InnerString : IInnerManager<string> { public override int Inner(string t) { return 2; } }
        public class InnerStringArray : IInnerManager<string[]> { public override int Inner(string[] t) { return 3; } }
    }
