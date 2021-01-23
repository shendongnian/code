    class Program
    {
        static void Main(string[] args)
        {
            var b = new B();
            b.Do();
        }
    }
    
    public class A
    {
        public virtual void Do()
        {
            var get = Get();
            Console.WriteLine(get);
        }
    
        private string Get()
        {
            return "A";
        }
    }
    
    public class B : A
    {
        public override void Do()
        {
            base.Do();
    
            var get = Get();
            Console.WriteLine(get);
        }
    
        private string Get()
        {
            return "B";
        }
    }
 
