    public class Ninject_34091099
    {
        public static void Run()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IInterface<Generic1>>()
                      .To<Class<Generic1>>()
                      .WithConstructorArgument("name", "STRING ONE");
                kernel.Bind<IInterface<Generic2>>()
                    .To<Class<Generic2>>()
                    .WithConstructorArgument("name", "The other string");
                kernel.Bind<IServiceFactory>().ToFactory().InSingletonScope();
                var factory = kernel.Get<IServiceFactory>();
                var c1 = factory.CreateInterface<Generic1>();
                var c2 = factory.CreateInterface<Generic2>();
                Console.WriteLine(c1.Name);
                Console.WriteLine(c2.Name);
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
    public interface IInterface<T> where T : class
    {
        string Name { get; set; }
    }
    public class Generic1
    {
    }
    public class Generic2
    {
    }
    public class Class<T> : IInterface<T> where T : class
    {
        public string Name { get; set; }
        public Class(string name)
        {
            Name = name;
        }
    }
    public interface IServiceFactory
    {
        IInterface<T> CreateInterface<T>() where T : class;
    }
