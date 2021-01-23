    public interface IClassA
    {
    }
    public interface IClassB
    {
    }
    public interface IClassC
    {
    }
    public class ClassA: IClassA
    {
        public ClassA(IClassB classb, IClassC classc)
        {
            Console.WriteLine("ClassA");
            Console.WriteLine("  ClassB: {0}", classb.GetType());
            Console.WriteLine("  ClassC: {0}", classc.GetType());
        }
    }
    public class ClassB : IClassB
    {
        public ClassB(IClassC classc)
        {
            Console.WriteLine("ClassB");
            Console.WriteLine("  ClassC: {0}", classc.GetType());
        }
    }
    public class ClassC1 : IClassC
    {
        public ClassC1()
        {
            Console.WriteLine("ClassC1");
        }
    }
    public class ClassC2 : IClassC
    {
        public ClassC2()
        {
            Console.WriteLine("ClassC2");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = ConfigureDependencies();
            container.GetInstance<IClassA>();
            container.GetInstance<IClassB>();
        }
        private static IContainer ConfigureDependencies()
        {
            return new Container(x =>
            {
                x.For<IClassA>().Use<ClassA>();
                x.For<IClassB>().Use<ClassB>();
                x.For<IClassC>().Use(z => z.RootType == typeof(ClassA) ? (IClassC) z.GetInstance<ClassC1>() : z.GetInstance<ClassC2>());
                x.For<IClassC>().UseIfNone<ClassC2>();
            });
        }
    }
