    class A<T> where T : IComparable
    {
    }
    class ComparableWrapper<T> : IComparable
          where T : IComparable<T>
    {
        T _obj;
        public ComparableWrapper(T obj)
        {
            _obj = obj;
        }
        public T WrappedObject {get { return _obj;}}
        
        // wrapping code
    }
