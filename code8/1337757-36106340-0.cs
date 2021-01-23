    public string loadFile(string filename)
    {
        FileStream fs;
        StreamReader sr;
        fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        sr = new StreamReader(fs);
        _reachedEnd= false;
        while(!sr.EndOfStream)
        {
            string content = sr.ReadToEnd();       
        }
        _reachedEnd= true;      
        fs.Close();
        return content;
    }
