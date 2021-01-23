    [System.ComponentModel.Composition.ImportingConstructorAttribute]
    public DropboxFolderWatchMessageReader(IConfig config, [ImportMany(typeof(IMessageReader))]
    IEnumerable<IMessageReader> readers;)
    {
        this.reader = readers.ToList();
        // rest of body
    }
