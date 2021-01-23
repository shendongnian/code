    class Test<T>
    {
        public void Stuff()
        {
            T t;
            t = new T(); // COMPILE TIME ERROR - type T may not have a parameterless constructor
        }
    }
