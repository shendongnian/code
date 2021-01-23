    public class CircularBuffer<T>
    {
        private T[] _buffer;
        public CircularBuffer(int count)
        {
            _buffer = new T[count];
        }
        public void Write(T element)
        {
            _buffer[WriteIndex] = element;
            WriteIndex++;
            if (WriteIndex >= _buffer.Length)
                WriteIndex = 0;
        }
        public bool TryRead(out T element)
        {
            // if the readindex equals the write index, means that there are no items in the buffer.
            if (ReadIndex == WriteIndex)
            {
                element = default(T);
                return false;
            }
            element = _buffer[ReadIndex];
            ReadIndex++;
            if (ReadIndex >= _buffer.Length)
                ReadIndex = 0;
            return true;
        }
        public IEnumerable<T> ReadAll()
        {
            T element;
            // read until the readindex is equal to the writeindex
            while (TryRead(out element))
                yield return element;
        }
        public int ReadIndex { get; private set; }
        public int WriteIndex { get; private set; }
    }
