    internal class Program
    {
        private static void Main(string[] args)
        {
            byte b1 = 0xc0;
            IEnumerable<bool> bits = GetBits(b1);
            byte b2 = GetByte(bits);
            byte b3 = GetByte(bits.Reverse());            
        }
        private static IEnumerable<bool> GetBits(byte b)
        {
            for (int i = 0; i < 8; i++)
            {
                yield return (b & 0x80).Equals(0x80);
                b = Convert.ToByte((b << 1) & 0xff);
            }
        }
        private static byte GetByte(IEnumerable<bool> bits)
        {
            byte b = 0x00;
            foreach (bool bit in bits)
            {
                b = Convert.ToByte((b << 1) & 0xff);
                if (bit) b = Convert.ToByte((b | 0x01) & 0xff);
            }
            return b;
        }
    }
