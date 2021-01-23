    using (var reader = new StreamReader(File.OpenRead("c:/yourfile.txt"), 
                                         Encoding.GetEncoding("iso-8859-1"))) 
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(';'); // replace ';' by the your separator
    
            string header1 = values[0];
            string header2 = values[1];
            string header3 = values[2];
            //...
        }
    }
