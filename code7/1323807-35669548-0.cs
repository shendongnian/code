    public interface IFileReader
    {
        string ReadFile( string filePath );
    }
    public class FileReader : IFileReader
    {
        public string ReadFile( string filePath )
        {
            return System.IO.File.ReadAllText( filePath );
        }
    }
