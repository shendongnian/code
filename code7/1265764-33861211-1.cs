    class A<T>
    {
        public int field1;
        public T field2;
        public event EventHandler Event1;
    }
    class Program
    {
        static void Main(string[] args)
        {
            A<bool> a = new A<bool>();
            Func<object, int> field1Getter =
                CreateFieldValueGetter<int>(a.GetType(), a.GetType().GetField("field1"));
            Func<object, bool> field2Getter =
                CreateFieldValueGetter<bool>(a.GetType(), a.GetType().GetField("field2"));
            Func<object, EventHandler> event1Getter =
                CreateFieldValueGetter<EventHandler>(a.GetType(), a.GetType()
                    .GetField("Event1", BindingFlags.NonPublic | BindingFlags.Instance));
        }
        static Func<object, T> CreateFieldValueGetter<T>(Type declaringType, FieldInfo fieldToGet)
        {
            var paramExp = Expression.Parameter(typeof(object));
            // ArgumentException if declaringType describes generic-type:
            var cast = Expression.Convert(paramExp, declaringType);
            var body = Expression.Field(cast, fieldToGet);
            return Expression.Lambda<Func<object, T>>(body, paramExp).Compile();
        }
    }
