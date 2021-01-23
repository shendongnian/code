    public class Array2<T>
    {
        private readonly T[,] _array;
        private bool _isEmpty;
        public Array2(int width, int height)
        {
            _array = new T[width, height];
            _isEmpty = true;
        }
        public T this[int x, int y]
        {
            get { return _array[x, y]; }
            set
            {
                _array[x, y] = value;
                _isEmpty = _isEmpty && value.Equals(default(T));
            }
        }
        public bool IsEmpty
        {
            get { return _isEmpty; }
        }
    }
