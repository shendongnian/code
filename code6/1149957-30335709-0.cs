    public sealed class FloatArrayAdaptor : IReadOnlyList<float>
    {
        private Vector2f[] _data;
        public FloatArrayAdaptor(Vector2f[] data)
        {
            _data = data;
        }
        public IEnumerator<float> GetEnumerator()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                yield return _data[i].x;
                yield return _data[i].y;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int Count
        {
            get { return 2*_data.Length; }
        }
        public float this[int index]
        {
            get
            {
                //TODO: Add appropriate range checking and whatnot
                int i = index>>1;
                bool isX = (index & 0x1) == 0;
                return isX ? _data[i].x : _data[i].y;
            }
        }
    }
