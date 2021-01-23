    List<string> allLines = System.IO.File.ReadLines(pathToFile).ToList();
    allLines = allLines.OrderBy(line => line).ToList(); //this orders alphabetically all your lines
    foreach (string line in allLines)
    {
        Console.WriteLine(line);
    }
