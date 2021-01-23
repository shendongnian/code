    public class VectorDictionary<TValue>
    {
        private C5.TreeDictionary<double, (Vector, TValue)> _dictX =
            new C5.TreeDictionary<double, (Vector, TValue)>();
        public int Count => _dictX.Count;
        public bool TryGetValue(Vector key, out TValue value)
        {
            var rangeX = _dictX.RangeFromTo(key.X - Vector.TOL, key.X + Vector.TOL);
            var equalVectors = rangeX.Where(e => e.Value.Item1.Equals(key));
            // Selecting a vector from many "equal" vectors is tricky.
            // Some may be more equal than others. :-) Lets return the first for now.
            var selectedVector = equalVectors.FirstOrDefault().Value;
            value = selectedVector.Item2;
            return selectedVector.Item1 != null;
        }
        public TValue this[Vector key]
        {
            get
            {
                if (TryGetValue(key, out var value)) return value;
                throw new KeyNotFoundException();
            }
        }
        public bool Contains(Vector key) => TryGetValue(key, out var _);
        public bool Add(Vector key, TValue value)
        {
            if (Contains(key)) return false;
            _dictX.Add(key.X, (key, value));
            return true;
        }
    }
