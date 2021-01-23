    var lineCount = 0;
    string line = string.Empty;
    using (var readerlines = File.OpenText(strfilename))
    {
        while ((line = readerlines.ReadLine()) != null)
        {
            if (!line.equals(string.Empty))
            {
                lineCount++;
            }   
        }
    }
