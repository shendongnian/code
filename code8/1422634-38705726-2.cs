    //  Semantically, this is basically a pointer to a pointer, without the asterisks.
    public class Reference<T>
    {
        public Reference() { }
        public Reference(T t) { Value = t; }
        public T Value;
    }
