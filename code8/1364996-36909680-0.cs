    public class SomeType
    {
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }
    
    public interface NormalInt<T>
    {
        void bsPro(T body);
    }
    
    public class Generic<T> : NormalInt<T>
        where T : SomeType
    {
        public void bsPro(T body)
        {
            body.Hello();
        }
    }
    
    public class Program
    {
        private static void Main(string[] args)
        {
            var g = new Generic<SomeType>();
            var s = new SomeType();
    
            g.bsPro(s);
        }
    }
