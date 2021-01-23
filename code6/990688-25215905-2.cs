    abstract class A
    {
    }
    
    class A1 : A
    {
    }
    
    class A2 : A
    {
    }
    
    class A3 : A
    {
    }
    
    #region Not a good idea, because too many classes
    
    class A1_with_c : A1
    {
        public void c() { }
    }
    
    class A2_with_c : A2
    {
        public void c() { }
    }
    
    class A3_with_c : A3
    {
        public void c() { }
    }
    
    #endregion
    
    
    // Decorate A with the c() method
    class BaseDecorator
    {
        public A Instance { get; private set; }
        public BaseDecorator(A instance)
        {
            Instance = instance;
        }
    
        public virtual void c()
        {
            // do something with instance
        }
    }
    
    class Decorator : BaseDecorator
    {
        BaseDecorator decorator;
        public Decorator(BaseDecorator decorator)
            : base(decorator.Instance)
        {
            this.decorator = decorator;
        }
        public override void c()
        {
            Console.WriteLine("Ok");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // not good
            new A1_with_c().c();
            new A2_with_c().c();
            new A3_with_c().c();
    
            // better
            var a_with_c = new BaseDecorator(new A1());
            a_with_c.c();
    
            // Let's decorate with something interesting
            new Decorator(a_with_c).c();
        }
    }
