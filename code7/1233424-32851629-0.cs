    class Program
    {
        public static void Main()
        {
            B instance = new A<B>();
            Console.WriteLine(instance.Name);
            Console.Read();
        }
    }
    
    public class A<T> : B where T : B { }
    public class B
    {
        public string Name { get { return "B"; } }
    }
