    var allLinesInFile = new List<string>(System.IO.File.ReadAllLines(file));
    var isPlayerScore = false;
    var linesToWrite = new List<string>();
    var linesToAdd = new List<string> {
      "itemDef\n\r",
      "{",
      " name \"zombiecounter\"\n\r",
      //and so on
      "}"
    };
    foreach (var line in allLinesInFile)
    {
      linesToWrite.Add(line);
      if (line.IndexOf("playerscores", StringComparison.OrdinalIgnoreCase) >= 0)
      { 
         //starting of data detected. 
         isPlayerScore = true;
      }
      else if (isPlayerScore == true && line.IndexOf("}"))
      {
         //end of data detected
         isPlayerScore = false;
         linesToWrite.AddRange(linesToAdd);
      }
    }
    System.IO.File.WriteAllLines(file, linesToWrite);
    MessageBox.Show("done");
