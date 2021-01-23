    public abstract class Matrix<T>
    {
        public static HashSet<Type> AllowAdd = new HashSet<Type>
        {
            typeof(int),
            typeof(long),
            typeof(string),
            typeof(double),
        };
        public T Add<T>(T first, T second)
        {
            if(!AllowAdd.Contains(typeof(T)))
            {
                throw new Exception(string.Format("Cannot preform addition for type: {0}", typeof(T).Name));
            }
            dynamic result = (dynamic)first + (dynamic)second;
            return (T)result;
        }
    }
