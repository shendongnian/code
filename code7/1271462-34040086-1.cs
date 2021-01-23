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
            Console.WriteLine(Get());
        }
        public virtual string Get()
        {
            return "A";
        }
    }
    public class B : A
    {
        public override void Do()
        {
            Console.WriteLine(base.Get());
            base.Do();
        }
        public override string Get()
        {
            return base.Get() + "B";
        }
    }
 
