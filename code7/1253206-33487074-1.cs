    var linesToWrite = new List<string>();
    for (var i = 0; i < allLinesInFile.Count; i++)
    {
      if (linesSansPlayerScore.Contains(i))
      {
        linesToWrite(allLinesInFile[i]);
      }
    }
    
    System.IO.File.WriteAllLines(file, linesToWrite);
    MessageBox.Show("done");
