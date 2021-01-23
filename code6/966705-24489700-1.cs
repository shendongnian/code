    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication4
    {
        using System.ComponentModel.Composition;
        using System.ComponentModel.Composition.Hosting;
        using System.Reflection;
    
        class Program
        {
            static void Main(string[] args)
            {
                var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                var directoryCatalog = new DirectoryCatalog(".");
                var compositeCatalog = new AggregateCatalog(assemblyCatalog, directoryCatalog);
                var container = new CompositionContainer(compositeCatalog);
                var a = A.Instance;
                container.SatisfyImportsOnce(a);
                a.PrintCatalog();
            }
        }
    
        public sealed class A
        {
            private static readonly A instance = new A();
    
            static A() { }
    
            private A() { }
    
            public static A Instance { get { return instance; } }
    
            [ImportMany]
            private List<IBType> BTypes;
    
            public void PrintCatalog()
            {
                foreach (var bType in BTypes)
                {
                    Console.WriteLine(bType.GetType());
                }
            }
    
        }
    
        [Export(typeof(IBType))]
        class B:IBType
        {
            static B()
            {
            }
    
            protected B()
            {}
    
            public void DoSomething() {  }
        }
    
        [Export(typeof(IBType))]
        class B2:IBType
        {
            static B2()
            {
            }
    
            protected B2()
            {}
    
            public void DoSomething() {  }
        }
    
        interface IBType
        {
            void DoSomething();
        }
    
    }
