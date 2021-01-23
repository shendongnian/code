    class Baseclass
    {
        public virtual void fun()
        {
            Console.WriteLine("Hi ");
        }
    }
    
    
    class Derived : Baseclass
    {
        public override void fun()
        {
            Console.Write("Bye ");
        }
    }
