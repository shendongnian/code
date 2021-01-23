    // Assuming this BlockingCollection is already filled with all string file paths
    private BlockingCollection<string> _blockingFileCollection = new BlockingCollection<string>();
    public bool TryProcessFile(string originalFile, out string changedFileName)
    {
        FileInfo fileInfo = new FileInfo(originalFile);
        changedFileName = Path.ChangeExtension(originalFile, ".original." + DateTime.Now.ToFileTime());
        string itemToProcess;
        if (_blockingFileCollection.TryTake(out itemToProcess))
        {
            return false;
        }
        // The file should exclusively be moved by one thread,
        // all other should return false.
        File.Move(originalFile, changedFileName);
        return true;
    }
