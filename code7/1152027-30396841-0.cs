    class BasicType<T> where T :  BasicType<T>, new()
    {
        public BasicType() { }
        public T Save() 
        {
            T b = new T();
            return (T)Activator.CreateInstance(typeof(T), b);
        }
    }
    class DerivedType : BasicType<DerivedType>
    {
        public DerivedType() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DerivedType d = new DerivedType();
            d = d.Save();
        }
    }
