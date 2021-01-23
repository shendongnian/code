    namespace FactoryTest
    {
        class Component : IDisposable
        {
            public delegate Component Factory(int i);
            public Component(int i) { Console.WriteLine(i); }
    
            public void Dispose()
            {
                Console.WriteLine("Component disposed");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
               var builder = new ContainerBuilder();
    
                builder.RegisterType<Component>().AsSelf();
          
                IContainer root = builder.Build();
    
                using (ILifetimeScope lf = root.BeginLifetimeScope())
                {
                    var compDelegatefac = lf.Resolve<Component.Factory>();
                    Component cmp = compDelegatefac(2);
                }
                GC.Collect();
            
                Console.Read();
             }
        }
     }
