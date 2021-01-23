    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Diagnostics;
    namespace BarFoo
    {
        class Program
        {
            static void Main(string[] args)
            {
                Foo foo1 = new Foo();
                Bar bar1 = new Bar1();
                Bar bar2 = new Bar2();
                foo1.Bar1Collection.Add(bar1);
                foo1.Bar2Collection.Add(bar2);
                Debug.Assert(bar1.Parent != null);
                Debug.Assert(bar2.Parent != null);
                bar1.DoSomething();
                bar2.DoSomething();
                Console.WriteLine("Done");
                Console.ReadLine();
                foo1.Dispose();
            }
        }
    }
