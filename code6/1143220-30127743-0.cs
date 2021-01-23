    using System;
    
    namespace ConsoleApplication2
    {
    
        public class EvManager
        {
            public delegate int SumDelegate(int a, int b);
            private SumDelegate sum;
    
            public void AddDelegate(SumDelegate s)
            {
                sum += s;
            }
    
            public void ExecuteIt(int a, int b)
            {
                foreach (var m in sum.GetInvocationList())
                {
                    Console.WriteLine("{0}({1}, {2}) = {3}", m.Method.Name, a, b, m.DynamicInvoke(a, b));
                }
    
            }
        }
    
        public class Class1
        {
            public Class1(EvManager m)
            {
                m.AddDelegate(FakeSum);
            }
    
            public int FakeSum(int a, int b)
            {
                return a - b;
            }
        }
    
        public class Class2
        {
            public Class2(EvManager m)
            {
                m.AddDelegate(RealSum);
            }
    
            public int RealSum(int a, int b)
            {
                return a + b;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var manager = new EvManager();
                var class1 = new Class1(manager);
                var class2 = new Class2(manager);
    
                manager.ExecuteIt(5, 12);
            }
        }
    }
