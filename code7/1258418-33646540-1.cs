    using(FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
    {
        StreamReader sr = new StreamReader(fs);
        using (StreamWriter sw = new StreamWriter(fs))
        {
            newString = someStringTransformation(sr.ReadToEnd());
    
            // discard the contents of the file by setting the length to 0
            fs.SetLength(0); 
    
            // write the new content
            sw.Write(newString);
        }
    }
