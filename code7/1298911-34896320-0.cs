    class Foo1
    {
        public Foo1()
        {
            Console.WriteLine("begin Foo1");
            Thread.Sleep(1000);
            Console.WriteLine("end Foo1");
        }
    }
    class Foo2
    {
        public Foo2()
        {
            Console.WriteLine("begin Foo2");
            Thread.Sleep(1000);
            Console.WriteLine("end Foo2");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Foo1>().AsSelf().SingleInstance();
            builder.RegisterType<Foo2>().AsSelf().SingleInstance();
            IContainer container = builder.Build();
            var t1 = Task.Run(() => container.Resolve<Foo1>());
            var t2 = Task.Run(() => container.Resolve<Foo2>());
            Task.WaitAll(t1, t2);
        }
    }
