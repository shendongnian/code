    public class InitializeGrid
    {
        IFileWrapper fileWrapper;
        public InitializeGrid (IFileWrapper fileWrapper)
        {
            this.fileWrapper = fileWrapper;
        }
        public List<List<char>> CreateCharMatrix (string filePathName)
        {
            string inputGridTextFile = fileWrapper.ReadTextFromFile (filePathName);
            // More code here...
        }
    }
