    string sInput = "";
    using (var reader = new StreamReader(sTemplateFilePath))
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            sInput = sInput + line;
    
        }
        reader.Close();
    }
