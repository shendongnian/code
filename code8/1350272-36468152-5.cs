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
                //Execute on dd1
                var g = (dd1)c.list[0];
                //Now you can access dd1's methids and not only the Interfaces
                Console.WriteLine("dd1");
            }
            else if (c.list[0].GetType() == typeof(dd2))
            {
                //Execute on dd2
                var g = (dd2)c.list[0];
                //Now you can access dd2's methids and not only the Interfaces
                Console.WriteLine("dd2");
            }
        }
    }
