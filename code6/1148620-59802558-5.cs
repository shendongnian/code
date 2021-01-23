    public class Wrapper<T> where T : struct
    {
        public static implicit operator T(Wrapper<T> w)
        {
            return w.Value;
        }
        public Wrapper(T t)
        {
            _t = t;
        }
        public T Value
        {
            get
            {
                return _t;
            }
            set
            {
                _t = value;
            }
        }
        public override string ToString()
        {
            return _t.ToString();
        }
        private T _t;
    }
