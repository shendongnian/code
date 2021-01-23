    class MyClass<T>
    {
        public MyClass()
        {
            if (typeof (T).IsClass)
            {
                Debugger.Break();
            }
            else if (typeof (T).IsValueType)
            {
                //do something
            }
        }
    }
