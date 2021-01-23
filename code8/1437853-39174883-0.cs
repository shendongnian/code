    [ContractClass(typeof(IFileClientContract))]
    public interface IFileClient
    {
         File GetFile(string path);
         Task<File> GetFileAsync(string path);
         void MoveFile(string source, string destination);
    }
    
    [ContractClassFor(typeof(IFileClient))]
    public abstract class IFileClientContract : IFileClient
    {
         public File GetFile(string Path)
         {
              Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(path));
    
              throw new NotImplementedException();
         }
    
         public Task<File> GetFileAsync(string path)
         {
              Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(path));
    
              throw new NotImplementedException();
         }
    
    
         public void MoveFile(string source, string destination)
         {
              Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(source));
              Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(destination));
    
              throw new NotImplementedException();
         }
    }
    
    // Any implementation of IFileClient will need to fulfill 
    // its contracts, including derived classes of FileClient!
    public abstract class FileClient : IFileClient
    {
         public abstract File GetFile(string Path);
         public abstract Task<File> GetFileAsync(string Path);
         public abstract void MoveFile(string Source, string Destination);
    }
