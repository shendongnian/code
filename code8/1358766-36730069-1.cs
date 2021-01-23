    public class Program
    {
        public static void Main()
        {
            var stream = new IOLibrary.Stream();
            var mbrParser = new MBRParser();
            var mbr = mbrParser.Read(stream);
        }
    }
