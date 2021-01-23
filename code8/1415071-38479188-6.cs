    public interface IFoo
    {
        void Bar();
    }
    public class FooNamed : IFoo
    {
        public void Bar()
        {
            Console.WriteLine("named one");
        }
    }
    public class FooDefault : IFoo
    {
        public void Bar()
        {
            Console.WriteLine("default one");
        }
    }
