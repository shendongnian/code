    using (var textReader = new StreamReader(fileName))
    {
        // read all text and divide into lines:
        var allText = textReader.ReadToEnd();
        var allLines = textReader.Split(new char[] {'\r','\n'}, StringSplitIoptions.RemoveEmptyEntries);
         // split each line based on ':', and take the fourth element
         var myValues = allLines.Select(line => line.Split(new char[] {':'})
             .Skip(3)
             .FirstOrDefault();
    }
