    public class FileIO : IDisposable
    {
        private FileStream streamResult = null;
        public FileStream GetFileStream(string myFile)
        {
            streamResult = File.Open(myFile, FileMode.Open);
            //Do something
            return streamResult;
        }
        public void Dispose()
        { 
           if (streamResult != null) streamResult.Dispose();         
        }
    }
    using (var io = FileIO())
    {
        var stream = io.GetFileStream(myFile);
        // loop goes here.
    }
