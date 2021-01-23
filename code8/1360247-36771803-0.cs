    namespace FactoryTest
    {
        class Component : IDisposable
        {
            public Component(int i) { Console.WriteLine(i);  }
    
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
                //Just Register
                builder.RegisterType<Component>().AsSelf();
    
                IContainer root = builder.Build();
    
                using (ILifetimeScope lf = root.BeginLifetimeScope())
                {
                    Func<int, Component> compDelegatefac = lf.Resolve<Func<int, Component>>();
                    Component cmp = compDelegatefac(2);
                }
                GC.Collect();
            
                Console.Read();
             }
        }
     }
