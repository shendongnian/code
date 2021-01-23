    public interface IFileWrapper
    {
        void Copy(string sourceFileName,string destFileName,bool overwrite);
        //Other required file system methods and properties here...
    }
    public class FileWrapper : IFileWrapper
    {
        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            File.Copy(sourceFileName, destFileName, overwrite);
        }
    }
