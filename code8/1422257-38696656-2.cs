    public abstract class MyClass where T : AbstractObject, new()
    {
        public MyClass(T type)
        {
            T instance = new T();
        }
    }
