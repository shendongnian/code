    public class MyWhateverBuffer<T>
    {
        private CircularBuffer<T[,]> _buffer;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }
        public MyWhateverBuffer(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
            _buffer = new CircularBuffer<T[,]>(depth);
        }
        public T[,] New()
        {
            return new T[Width, Height];
        }
        public bool Add(T[,] buffer)
        {
            return _buffer.Write(buffer);
        }
        public bool TryRead(out T[,] buffer)
        {
            return _buffer.TryRead(out buffer);
        }
        public IEnumerable<T[,]> ReadAll()
        {
            return _buffer.ReadAll();
        }
    }
