    List<string> allLines = System.IO.File.ReadLines(pathToFile).ToList();
    foreach (string line in allLines)
    {
        char[] lineCharacters = line.ToCharArray();
        //work with lineCharacters
    }
