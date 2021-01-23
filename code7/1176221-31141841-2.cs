    public class MyType<TBase>
    {
        private Type Value;
        protected MyType()
        {
        }
        public static implicit operator Type(MyType<TBase> type)
        {
            return type.Value;
        }
        public static implicit operator MyType<TBase>(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException();
            }
            if (!typeof(TBase).IsAssignableFrom(type))
            {
                throw new ArgumentException();
            }
            return new MyType<TBase> { Value = type };
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var type = obj as MyType<TBase>;
            return type != null && Value.Equals(type.Value);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
