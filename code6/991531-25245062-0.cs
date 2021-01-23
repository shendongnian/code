    -- other class --
    public IEnumerable<Filenames> GetFilenames()
    {
        return new List<Filenames> { new Filenames { name = "filename1", id = 1 } };
    }
    --MainForm--
    this.filenamesList.Clear();
    this.filenamesList.AddRange(otherclass.GetFilenames());
 
