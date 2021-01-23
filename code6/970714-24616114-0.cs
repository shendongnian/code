    public interface IFileSystem
    {
        void WriteAllText(string filePath, string fileContents);	
        bool Exists(string filePath);
    }
    
    public class RealFileSystem : IFileSystem
    {
        public void WriteAllText(string filePath, string fileContents)
        {
            File.WriteAllText(filePath, fileContents);
        }
        public void Exists(string filePath) 
        {
            return File.Exists(filePath);
        }
    }
    
    public class TestFileSystem : IFileSystem
    {
        public Dictionary<string, string> fileSystem = new Dictionary<string, string>();
        public void WriteAllText(string filePath, string fileContents)
        {
         	fileSystem.Add(filePath, fileContents);
        }
        public void Exists(string filePath) 
        {
        	return fileSystem.ContainsKey(filePath);
        }
    }
