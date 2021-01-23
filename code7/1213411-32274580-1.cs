    var lineNumber = 0;
    using (var newFile = File.AppendText(@"c:\temp\new.sql"))
    {
        foreach (var line in File.ReadLines(@"c:\temp\old.sql"))
        {
            lineNumber++;
            var updatedLine = line.Replace("('',", "('" + lineNumber.ToString() + "',");
            newFile.WriteLine(updatedLine);
        }
    }
