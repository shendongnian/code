    public abstract class MyClass<T> where T : AbstractObject, new()
    {
        public MyClass(T type)
        {
            T instance = new T();
        }
    }
