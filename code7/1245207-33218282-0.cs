    public class MyStaticClass
    {
        public static List<Type> ClosedTypes = new List<Type>();
    }
    public class MyGenericType<T>
    {
        static MyGenericType()
        {
            MyStaticClass.ClosedTypes.Add(typeof(MyGenericType<T>));
        }
    }
