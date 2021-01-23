    public enum MyEnum
    {
        Value1, Value2, Value3, Value4
    }
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class MyClassHandlerAttribute : Attribute
    {
        public MyEnum Handles { get; private set; }
        public MyClassHandlerAttribute(MyEnum handles) { Handles = handles; }
    }
    public abstract class MyClass
    {
        public abstract int Function(int x, int y);
    }
    public static class MyClassFactory
    {
        public static MyClass Create(MyEnum type)
        {
            var handler = Assembly.GetExecutingAssembly().GetTypes().Where(t =>
            {
                var a = t.GetCustomAttribute<MyClassHandlerAttribute>();
                if (a.Handles == type)
                    return true;
                return false;
            }).FirstOrDefault();
            if (handler != null)
                return Activator.CreateInstance(handler) as MyClass;
            return null;
        }
    }
    [MyClassHandler(MyEnum.Value1)]
    public sealed class MyClassType1 : MyClass
    {
        public int Function(int x, int y) { return x * y; }
    }
    [MyClassHandler(MyEnum.Value2)]
    public sealed class MyClassType2 : MyClass
    {
        public int Function(int x, int y) { return x * x + y; }
    }
