    private AddedContentReader _freader;
    protected override void OnStart(string[] args)
    {
        _freader = new AddedContentReader("E:\\tmp\\test.txt");
        //If you have saved the last position when the application did exit then you can use that value here to start from that location like the following
        //_freader = new AddedContentReader("E:\\tmp\\test.txt",lastReadPosition);
    }
    private void Watcher_Changed(object sender, FileSystemEventArgs e)
    {
        string addedContent= _freader.GetAddedLines();
        //you can do whatever you want with the lines
    }
