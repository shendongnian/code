    public class MBRParser
    {
        public MasterBootRecord Read(Stream stream)
        {
            // parsing logic
        }
        public MasterBootRecord Read(IMBRReader reader)
        {
            // parsing logic
        }
    }
    public interface IMBRReader
    {
        MasterBootRecord Read();
    }
