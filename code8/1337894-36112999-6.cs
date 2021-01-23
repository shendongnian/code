    public class CircularBuffer<T>
    {
        private T[] _buffer;
        private int IncRollover(int value)
        {
            value++;
            if (value >= _buffer.Length)
                value = 0;
            return value;
        }
        public CircularBuffer(int count)
        {
            _buffer = new T[count];
        }
        public bool Write(T element)
        {
            // if the writeindex (after increasing) equals the readindex, the buffer is full
            var newWriteIndex = IncRollover(WriteIndex);
            if (newWriteIndex == ReadIndex)
                return false;
            _buffer[WriteIndex] = element;
            WriteIndex = newWriteIndex;
            return true;
        }
        public bool TryRead(out T element)
        {
            if (ReadIndex == WriteIndex)
            {
                element = default(T);
                return false;
            }
            element = _buffer[ReadIndex];
            ReadIndex = IncRollover(ReadIndex);
            return true;
        }
        public IEnumerable<T> ReadAll()
        {
            T element;
            while (TryRead(out element))
                yield return element;
        }
        public int ReadIndex { get; private set; }
        public int WriteIndex { get; private set; }
    }
