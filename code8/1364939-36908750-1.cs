    interface IFactory<T> 
    {
        T CreateFrom(ISomething param);
    }
    class MyClass : IFactory<MyClass> 
    {
        public MyClass CreateFrom(ISomething param) { /* ... */ }
    }
