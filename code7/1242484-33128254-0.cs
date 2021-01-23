    private class GenericClass<T>
    {
        // T used in constructor.
        public GenericClass(T t)
        {
            data = t;
        }
    
        // T as private member data type.
        private T data;
    
        // T as return type of property.
        public T Data  
        {
            get { return data; }
            set { data = value; }
        }
    }
