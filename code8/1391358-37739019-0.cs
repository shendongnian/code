    var lines = this._fileProxy.ReadAllLines(file, Encoding.Unicode);
---------
    //some dummy code so I can compile
    public interface IProxyDir
    {
        IEnumerable<string> GetFiles(string path);
    }
    public class GdsCallDto
    {
    }
    public class Proxy : IProxyDir
    {
        public IEnumerable<string> GetFiles(string path)
        {
            throw new NotImplementedException();
        }
    }
    public interface IFileDir
    {
        IEnumerable<string> ReadAllLines(string path, Encoding encoding);
    }
    public class FileProxy : IFileDir
    {
        public IEnumerable<string> ReadAllLines(string path, Encoding encoding)
        {
            throw new NotImplementedException();
        }
    }
    public interface IFileMgr
    {
        string DeserializeFileContent(IEnumerable<string> lines, string content);
    }
    public class FileMgr : IFileMgr
    {
        public string DeserializeFileContent(IEnumerable<string> lines, string content)
        {
            throw new NotImplementedException();
        }
    }
    //system under test
    public class Sut
    {
        private IProxyDir _directoryProxy;
        private IFileDir _fileProxy;
        private IFileMgr _fileManager;
        public Sut(IProxyDir proxyDir,  IFileDir fileProxy, IFileMgr mgr)
        {
            _fileManager = mgr;
            _directoryProxy = proxyDir;
            _fileProxy = fileProxy;
        }
        public int LoadFilesAndSaveInDatabase(string filesPath)
        {
            var calls = new ConcurrentStack<GdsCallDto>();
            var filesInDirectory = this._directoryProxy.GetFiles(filesPath);
            if (filesInDirectory.Any())
            {
                Parallel.ForEach(filesInDirectory, file =>
                {
                    var lines = this._fileProxy.ReadAllLines("ssss", Encoding.Unicode);
                    if (lines.Any())
                    {
                        // Reads the file and setup a new DTO.
                        var deserializedCall = this._fileManager.DeserializeFileContent(lines, Path.GetFileName("file"));
                        // Insert the DTO in the database.
                        //this._gdsCallsData.InsertOrUpdateGdsCall(deserializedCall);
                        // We keep track of the dto to count the number of restored items.
                        //calls.Push(deserializedCall);
                    }
                });
            }
            
            return 1;
        }
    }
