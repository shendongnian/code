    class Test<T> where T : new()
    {
        public void Stuff()
        {
            T t;
            t = new T(); // IT IS OK - the type T must have parameterless constructor.
        }
    }
