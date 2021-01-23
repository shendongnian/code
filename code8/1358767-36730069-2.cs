    public class NativeMBRReader : IMBRReader
    {
        public MasterBootRecord Read()
        {
            // native I/O methods to read MBR
        }
    }
    public class Program
    {
        public static void Main()
        {
            var mbrReader = new NativeMBRReader();
            var mbr = mbrReader.Read();
        }
    }
