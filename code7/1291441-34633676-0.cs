    void Main()
    {
        Test(new Child1Factory());
        Test(new Child2Factory());
    }
    
    public void Test(IBaseFactory baseFactory)
    {
        Console.WriteLine("In Test(...");
        var b = baseFactory.Create();
    }
    
    public class Base
    {
        public Base(int value)
        {
            Console.WriteLine($"Base.ctor({value})");
        }
    }
    
    public interface IBaseFactory
    {
        Base Create();
    }
    
    public class Child1 : Base
    {
        public Child1(int value) : base(value)
        {
            Console.WriteLine($"Child1.ctor({value})");
        }
    }
    
    public class Child1Factory : IBaseFactory
    {
        public Base Create() => new Child1(42);
    }
    
    public class Child2 : Base
    {
        public Child2(string name) : base(name.Length)
        {
            Console.WriteLine($"Child2.ctor({name})");
        }
    }
    
    public class Child2Factory : IBaseFactory
    {
        public Base Create() => new Child2("Meaning of life");
    }
