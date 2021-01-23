    public interface IWriter
    {
        void WriteToStorage(string data);
    }
    public interface IFileWriter : IWriter
    {
    }
    public interface IDBWriter: IWriter
    {
    }
    public class FileWriter : IFileWriter 
    {
        public void WriteToStorage(string data)
        {
            //write to file
        }
    }
    public class DBWriter : IDBWriter
    {
        public void WriteToStorage(string data)
        {
            //write to DB
        }
    }
