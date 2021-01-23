    const int maxLinesPerFile = 5000000;
    int fileNumber = 0;
    var destinationFile = File.CreateText("outputFile"+fileNumber);
    int linesRead = 0;
    foreach (var line in File.ReadLines(inputFile))
    {
        ++linesRead;
        if (linesRead > maxLinesPerFile)
        {
            destinationFile.Close();
            ++fileNumber;
            destinationFile = File.CreateText("outputFile"+fileNumber);
        }
        destinationFile.WriteLine(line);
    }
    destinationFile.Close();
