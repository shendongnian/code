    public class MyClass<T> where T : IMyInterface
    {
        public List<T> list = new List<T>();
    }
    public interface IMyInterface
    {
    }
    public class Foo : IMyInterface
    {
    }
    public class Bar : IMyInterface
    {
    }
    public class FooBar
    {
        public void Test()
        {
            var content = new MyClass<IMyInterface>();
            content.list.Add(new Foo());
            if (content.list[0] is Foo)
            {
                //Execute on Foo 
                var g = (Foo)content.list[0];
                //Now you can access Foo's methods and not only the Interfaces
                Console.WriteLine("Foo");
            }
            else if (content.list[0] is Bar)
            {
                //Execute on Bar
                var g = (Bar)content.list[0];
                //Now you can access Bar's methods and not only the Interfaces
                Console.WriteLine("Bar");
            }
        }
    }
