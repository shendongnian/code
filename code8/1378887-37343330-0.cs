    internal class Program
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int memcmp(byte[] b1, byte[] b2, long count);
    
        private static bool ByteArrayCompare(byte[] b1, byte[] b2)
        {
            return b1.Length == b2.Length && memcmp(b1, b2, b1.Length) == 0;
        }
    
        private static void Main(string[] args)
        {        
            var str1 = Encoding.GetEncoding(437).GetBytes("Rémunération & avantages");
            var str2 = Encoding.GetEncoding(437).GetBytes("Rémunération ＆ avantages");
            Console.WriteLine(ByteArrayCompare(str1, str2));
            Console.ReadLine();
        }
    }
