    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication4
    {
        using System.ComponentModel.Composition;
        using System.ComponentModel.Composition.Hosting;
        using System.Linq;
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
                a.BTypes.Single(s=>s.Metadata.Name.Equals("Second")).Value.DoSomething();
            }
        }
    
        public sealed class A
        {
            private static readonly A instance = new A();
    
            static A() { }
    
            private A() { }
    
            public static A Instance { get { return instance; } }
    
            [ImportMany]
            public List<Lazy<IBType,IBTypeMetadata>> BTypes;
    
            public void PrintCatalog()
            {
                foreach (var bType in BTypes)
                {
                    Console.WriteLine(bType.Value.GetType());
                }
            }
    
        }
    
        [Export(typeof(IBType))]
        [BTypeMetadata("First")]
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
        [BTypeMetadata("Second")]
        class B2 : IBType
        {
            static B2()
            {
            }
    
            protected B2()
            {}
    
            public void DoSomething()
            {
                Console.WriteLine("Hello from Second");
            }
        }
    
        public interface IBType
        {
            void DoSomething();
        }
    
        public interface IBTypeMetadata
        {
            string Name { get; }
        }
    
        [MetadataAttribute]
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public class BTypeMetadataAttribute : ExportAttribute
        {
            public string Name { get; set; }
            public BTypeMetadataAttribute(string name)
                : base(typeof(IBTypeMetadata)) { Name = name; }
        }
    
    }
