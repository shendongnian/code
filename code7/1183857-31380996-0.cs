    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new B();
            var arr = new Base[] { a, b};
            foreach (var obj in arr)
                Console.WriteLine(obj.Caption);
            Console.ReadKey();
        }
    }
    public class Base<T> : Base
    {
        public override string Caption
        {
            get { return typeof (T).ToString(); }
        }
    }
    public class A : Base<A> { }
    public class B : Base<B> { }
    public abstract class Base
    {
        public abstract string Caption { get; }
    }
