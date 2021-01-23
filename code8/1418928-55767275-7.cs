    public class VectorDictionary<TValue>
    {
        private C5.TreeDictionary<double, (Vector, TValue)> _tree =
            new C5.TreeDictionary<double, (Vector, TValue)>();
        public bool TryGetKeyValue(Vector key, out (Vector, TValue) pair)
        {
            double xyz = key.X + key.Y + key.Z;
            // Hoping that not all vectors are crowded in the same diagonal line
            var range = _tree.RangeFromTo(xyz - Vector.TOL * 3, xyz + Vector.TOL * 3);
            var equalPairs = range.Where(e => e.Value.Item1.Equals(key));
            // Selecting a vector from many "equal" vectors is tricky.
            // Some may be more equal than others. :-) Lets return the first for now.
            var selectedPair = equalPairs.FirstOrDefault().Value;
            pair = selectedPair;
            return selectedPair.Item1 != null;
        }
        public Vector GetExisting(Vector key)
        {
            return TryGetKeyValue(key, out var pair) ? pair.Item1 : default;
        }
        public bool Contains(Vector key) => TryGetKeyValue(key, out var _);
        public bool Add(Vector key, TValue value)
        {
            if (Contains(key)) return false;
            _tree.Add(key.X + key.Y + key.Z, (key, value));
            return true;
        }
        public TValue this[Vector key]
        {
            get => TryGetKeyValue(key, out var pair) ? pair.Item2 : default;
            set => _tree.Add(key.X + key.Y + key.Z, (key, value));
        }
        public int Count => _tree.Count;
    }
