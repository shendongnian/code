    string Header1 = string.Empty;
    using (var reader = new StreamReader(File.OpenRead("c:/yourfile.txt"),
                             Encoding.GetEncoding("iso-8859-1")))
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(';'); // replace ';' by the your separator
            Header1 = values[0];
            //...
        }
    }
    grid.Columns[0].Header = Header1;
