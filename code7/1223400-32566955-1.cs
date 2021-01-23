    var streamReaderFileName = new StreamReader(fileName, Encoding.Default);
    var streamWriterNewName = new StreamWriter(newName, false, Encoding.GetEncoding(1252));
    yourLine = streamReaderFileName.ReadLine();
    while (yourLine!=null)
    {
    yourLineLength = yourLine.Length;
    yourNewLine = yourLine.PadRight(yourLineLength + numberOfSpaceYouWant)
    yourLine = streamReaderFileName.ReadLine();
    }
    streamWriterNewName.WriteLine(yourNewLine);
    streamReaderFileName.Close();
    streamWriterNewName.Close();
                
