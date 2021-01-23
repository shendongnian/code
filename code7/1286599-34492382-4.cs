    public class A
        {
            public virtual void MethodA()
            {
                Console.WriteLine("A:MethodA");
            }
        }
    
        public class B : A
        {
            public bool CallBase { get; set; }
    
            public B()
            {
                CallBase = false;
            }
    
            public override void MethodA()
            {
                if (CallBase)
                {
                    base.MethodA();
    
                    return;;
                }
    
                Console.WriteLine("B:MethodA");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A();
                B b = new B();
    
                a.MethodA();
                b.MethodA();
    
                b.CallBase = true;
    
                b.MethodA();
    
                Console.ReadKey();
            }
        }
