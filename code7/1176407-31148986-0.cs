    ...
    public class Program
    {
        private static void Main(string[] args)
        {
            ClassB<ClassA> objA = new ClassB<ClassA>();
            IClassB<ITestA<MyDTO>> objB = new ClassB<ClassA>();
        }
    }
    public interface IClassB<out T>
    {
        //some code here
    }
    public class ClassB<T> : IClassB<T>
    {
        //some code here
    }
    ...
