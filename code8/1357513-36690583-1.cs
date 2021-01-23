    public class STuple<T1, T2>
    {
        public STuple()
        {
        }
        public STuple(T1 t1, T2 t2)
            : this()
        {
            Item1 = t1;
            Item2 = t2;
        }
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        protected bool Equals(STuple<T1, T2> other)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) &&
                   EqualityComparer<T2>.Default.Equals(Item2, other.Item2);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((STuple<T1, T2>) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T1>.Default.GetHashCode(Item1)*397) ^
                       EqualityComparer<T2>.Default.GetHashCode(Item2);
            }
        }
        public static bool operator ==(STuple<T1, T2> left, STuple<T1, T2> right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(STuple<T1, T2> left, STuple<T1, T2> right)
        {
            return !Equals(left, right);
        }
        public static implicit operator Tuple<T1, T2>(STuple<T1, T2> st)
        {
            return Tuple.Create(st.Item1, st.Item2);
        }
        public static implicit operator STuple<T1, T2>(Tuple<T1, T2> t)
        {
            return new STuple<T1, T2>
            {
                Item1 = t.Item1,
                Item2 = t.Item2
            };
        }
    }
