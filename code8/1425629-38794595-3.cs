    //To read
    Encoding currentFileEnc = GetFileEncoding(TheFile);
    using (StreamReader sr = new StreamReader(TheFile, currentFileEnc))
    {
        //Blah blah blah
    }
    //To write back
    using (StreamWriter sw = new StreamWriter(TempFilePath, false, currentFileEnc))
    {
        //blah blah blah
    }
