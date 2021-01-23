    public class MyTruncatableArray<T>
    {
        private T[] _array;
        private int _length;
        public MyTruncatableArray(int size)
        {
            _array = new T[size];
            _length = size;
        }
        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return _array[index];
            }
            set
            {
                CheckIndex(index);
                _array[index] = value;
            }
        }
        public int Length
        {
            get { return _length; }
            set
            {
                CheckIndex(value);
                _length = value;
            }
        }
        private void CheckIndex(int index)
        {
            if (index < 0 || index > _array.Length)
            {
                throw new ArgumentException("New array length must be positive and lower or equal to original size");
            }
        }
    }
