    public interface IWriter
    {
        void WriteToStorage(string data);
        StorageType WritesTo { get; }
    }
    
    public enum StorageType 
    {
        Db = 1,
        File = 2
    }
    public class Factory : IFactory
    {
        public IEnumerable<IWriter> _writers;
    
        public Factory(IWriter[] writers)
        {
            _writers = writers;
        }
    
        public IWriter GetType(StorageType outputType)
        {
            IWriter writer = _writers.FirstOrDefault(x => x.WritesTo == outputType);
            return writer;
        }
    }
