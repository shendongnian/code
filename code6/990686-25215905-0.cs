    interface IDecorator
    {
        void Print();
    }
    
    class Concrete : IDecorator
    {
        public void Print()
        {
            Console.WriteLine("-> Concrete");
        }
    }
    
    class A : IDecorator
    {
        IDecorator decorator;
        public A(IDecorator decorator)
        {
            this.decorator = decorator;
        }
        public void Print()
        {
            decorator.Print();
            Console.WriteLine("-> A");
        }
    }
    
    class B : IDecorator
    {
        IDecorator decorator;
        public B(IDecorator decorator)
        {
            this.decorator = decorator;
        }
        public void Print()
        {
            decorator.Print();
            Console.WriteLine("-> B");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("concrete object that should be decorated");
            var concrete = new Concrete();
            concrete.Print();
    
            Console.WriteLine("let's decorate this object with A decorator");
            var decoratedWithA = new A(concrete);
            decoratedWithA.Print();
    
            Console.WriteLine("let's decorate this object with B decorator");
            var decoratedWithB = new B(concrete);
            decoratedWithB.Print();
    
            Console.WriteLine("let's decorate concrete with A and B");
            var decoratedWithAB = new B(new A(concrete));
            decoratedWithAB.Print();
        }
    }
