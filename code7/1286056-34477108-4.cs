    public class FileComparator
    {
        private const int _bufferCapacity = 0x400000; //4Mb
        public static bool AreEquals(string first, string second)
        {
            return AreEquals(File.OpenRead(first), File.OpenRead(second));
        }
        public static bool AreEquals(FileStream first, FileStream second)
        {
            using (var firstStream = new BufferedStream(first))
            using (var secondStream = new BufferedStream(second))
            {
                if (first.Length != second.Length)
                    return false;
                var firstBuffer = new byte[_bufferCapacity];
                var secondBuffer = new byte[_bufferCapacity];
                int bytesReadFirst;
                int bytesReadSecond;
                do
                {
                    bytesReadFirst = firstStream.Read(firstBuffer, 0, firstBuffer.Length);
                    bytesReadSecond = secondStream.Read(secondBuffer, 0, secondBuffer.Length);
                    if (bytesReadFirst != bytesReadSecond || !CompareByteArrays(firstBuffer, secondBuffer))
                        return false;
                } while (bytesReadFirst > 0 && bytesReadSecond > 0);
                return true;
            }
        }
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);
        private static bool CompareByteArrays(byte[] first, byte[] second)
        {
            return first.Length == second.Length && memcmp(first, second, first.Length) == 0;
        }
    }
