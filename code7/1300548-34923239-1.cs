    var lineCount = 0;
    using (var readerlines = File.OpenText(strfilename))
    {
        while (!string.IsNullOrEmpty(readerlines.ReadLine()))
        {
            lineCount++;
        }
    }
