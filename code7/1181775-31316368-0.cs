    public class A<T>
    {
        public static A<T> GetInstance()
        {
            return new A<T>();
        }
    }
    
    public class A : A<object>
    {
        public static new A GetInstance()
        {
            return new A();
        }
    
        public static A<T> GetInstance<T>()
        {
            return new A<T>();
        }
    }
