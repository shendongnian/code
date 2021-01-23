    public class Generic<T> : IComparable where T : new()
    {
        public bool IsArray()
        {
            return typeof(T).IsArray;
        }
        public T Create()
        {
            return new T();
        }
        public int CompareTo(object obj)
        {
            return 0;
        }
    }
    Type type = typeof(Generic<>).MakeGenericType(field.FieldType);
    IComparable cmp = (IComparable)Activator.CreateInstance(type);
    int res = cmp.CompareTo(cmp);
