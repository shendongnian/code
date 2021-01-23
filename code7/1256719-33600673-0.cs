    static class BigEndianBinaryReaderExtensions
    { 
        private static T ReadBigEndian<T>(BinaryReader r, Func<byte[], int, T> f)
        {
            int s = Marshal.SizeOf<T>(); // include System.Runtime.Interop;
            byte[] b = new byte[s];
            if (r.Read(b, 0, s) != s)
                throw new EndOfStreamException();
            if (BitConverter.IsLittleEndian) // for correct behavior on big-endian architectures
                Array.Reverse(b);
            return f(b, 0);
        }
        public static int ReadInt32BigEndian(this BinaryReader reader)
        {
            return ReadBigEndian(reader, BitConverter.ToInt32);
        }
        public static uint ReadUInt32BigEndian(this BinaryReader reader)
        {
            return ReadBigEndian(reader, BitConverter.ToUInt32);
        }
        public static long ReadInt64BigEndian(this BinaryReader reader)
        {
            return ReadBigEndian(reader, BitConverter.ToInt64);
        }
        public static ulong ReadUInt64BigEndian(this BinaryReader reader)
        {
            return ReadBigEndian(reader, BitConverter.ToUInt64);
        }
        public static short ReadInt16BigEndian(this BinaryReader reader)
        {
            return ReadBigEndian(reader, BitConverter.ToInt16);
        }
        public static ushort ReadUInt16BigEndian(this BinaryReader reader)
        {
            return ReadBigEndian(reader, BitConverter.ToUInt16);
        }
    }
