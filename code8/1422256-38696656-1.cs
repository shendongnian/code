    public abstract class MyClass
    {
        public MyClass(T type) where T : AbstractObject, new()
        {
            T instance = new T();
        }
    }
