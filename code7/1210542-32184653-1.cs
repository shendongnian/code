    public class SuperClass<T> where T: SuperClass<T>
    {
        public T SetThis()
        {
            ....
            return (T)this;
        }
    }
    
    public class SubClass : SuperClass<SubClass>
    {
    }
