    public class MyClass<T> where T : IMyInterface
    {
        public List<T> list = new List<T>();
    }
    public interface IMyInterface
    {
    }
    public class dd1 : IMyInterface
    {
    }
    public class dd2 : IMyInterface
    {
    }
    public class dd
    {
        public void ad()
        {
            var c = new MyClass<IMyInterface>();
            c.list.Add(new dd1());
            if (c.list[0].GetType() == typeof(dd1))
            {
                //Execute on ClassA_IMyInterface
                Console.WriteLine("dd1");
            }
            else if (c.list[0].GetType() == typeof(dd2))
            {
                //Execute on ClassB_IMyInterface
                Console.WriteLine("dd2");
            }
        }
    }
