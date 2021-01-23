    public abstract class MyClass
    {
        public MyClass(Type T) where T : AbstractObject, new()
        {
            T instance = new T();
        }
    }
