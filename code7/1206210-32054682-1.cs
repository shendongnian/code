    using (MemoryStream ms = new MemoryStream())
    {
        StreamWriter writer = new StreamWriter(ms);
    
        writer.WriteLine("asdasdasasdfasdasd");
        writer.Flush();
    
        //You have to rewind the MemoryStream before copying
        ms.Seek(0, SeekOrigin.Begin);
    
        using (FileStream fs = new FileStream("output.txt", FileMode.OpenOrCreate))
        {
            ms.CopyTo(fs);
            fs.Flush();
        }
    }
