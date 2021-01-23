    public BinaryDictionary(string name, string path = null)
    {
        fileName = name;
        if(path == null)
        {
             this.path = FileReadWrite.binPath;   
        }
    }
