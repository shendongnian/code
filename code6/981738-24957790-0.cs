    class Base
    {
        public void Hidden()
        {
            Console.WriteLine("Base!");
        }
        public virtual void Overrideable()
        {
            Console.WriteLine("Overridable BASE.");
        }
    }
    class Derived : Base
    {
        public void Hidden()
        {
            Console.WriteLine("Derived");
        }
        public override void Overrideable()
        {
            Console.WriteLine("Overrideable DERIVED");
        }
    }
