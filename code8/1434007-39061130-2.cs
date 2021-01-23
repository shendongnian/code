    public class Basic 
    {
        public double dim1;
    }
    public class Derived  : Basic
    {
        public double dim2;
    }
    public interface IFactory<in T>
    {
        double Area(T shape);
    }
    class BasicFactory : IFactory<Basic>
    {
        public double Area(Basic shape)
        {
            return shape.dim1 * shape.dim1;
        }
    }
    class DerivedFactory : IFactory<Derived>
    {
        public double Area(Derived shape)
        {
            return shape.dim1 * shape.dim2;
        }
    }
    class Program 
    {
        double Area(IFactory<Derived> factory, Derived shape)
        {
            return factory.Area(shape);
        }
        static void Main(string[] args)
        {
            IFactory<Basic> notDerived = new BasicFactory(); // from not derived type
            Derived shape = new Derived() { dim1 = 10, dim2 = 20 };
            double area = new Program().Area(notDerived,shape); // cast! dimension loss
            Console.WriteLine(area); // 100 = 10*10
            IFactory<Derived> derived = new DerivedFactory(); //from derived type
            area = new Program().Area(derived, shape); // no cast, now
            Console.WriteLine(area); // 200 = 10*20
            Console.ReadKey();
        }
    }
