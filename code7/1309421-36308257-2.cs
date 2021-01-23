    public abstract class Suple<T1, T2, T3>
    {
        private readonly T1 _item1;
        private readonly T2 _item2;
        private readonly T3 _item3;
        private readonly int? _cachedHash;
        protected Suple(T1 item1, T2 item2, T3 item3)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
        }
		protected Suple(T1 item1, T2 item2, T3 item3, SupleHash hashMode)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _cachedHash = CalculateHashCode();
        }
        protected T1 Item1 { get { return _item1; } }
        protected T2 Item2 { get { return _item2; } }
        protected T3 Item3 { get { return _item3; } }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            // here's the missing Tuple type comparison
            if (GetType() != obj.GetType()) return false;
            var other = (Suple<T1, T2, T3>) obj;
            // attempt to avoid equals comparison by using the
            // cached hash if provided by both objects
            if (_cachedHash != null &&
                other._cachedHash != null &&
                _cachedHash != other._cachedHash) return false;
            return Equals(_item1, other._item1) &&
                   Equals(_item2, other._item2) &&
                   Equals(_item3, other._item3);
        }
        public override int GetHashCode()
        {
			return _cachedHash ?? CalculateHashCode();
        }
        private int CalculateHashCode()
        {
		    unchecked
			{
		        int hashcode = 0;
                hashcode += _item1 != null ? _item1.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item2 != null ? _item2.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item3 != null ? _item3.GetHashCode() : 0;
			    return hashcode;
		    }
        }
    }
