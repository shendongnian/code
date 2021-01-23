    public class ByteCollection: List<byte>
    {
        public void Add(IEnumerable<byte> bytes)
        {
            AddRange(bytes);
        }
    }
