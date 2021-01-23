    var allLinesInFile = new List<string>(System.IO.File.ReadAllLines(file));
    var linesOfPlayerScore = new List<int>();
    var linesSansPlayerScore = new List<int>();
    var isPlayerScore = false;
    var lineIndex = 0;
    
    foreach (var line in allLinesInFile)
    {
      if (line.IndexOf("playerscores", StringCOmparison.OrdinalIgnoreCase) >= 0)
      { 
         //starting of data detected. 
         linesOfPlayerScore.Add(lineIndex -2); //itemDef
         linesOfPlayerScore.Add(lineIndex -1); //{
         linesOfPlayerScore.Add(lineIndex);
         isPlayerScore = true;
      }
      else if (isPlayerScore == true && line.IndexOf("}"))
      {
         //end of data detected
         linesOfPlayerScore.Add(lineIndex);
         isPlayerScore = false;
      }
      else if (isPlayerScore == true)
      { 
         //middle of data
         linesOfPlayerScore.Add(lineIndex);
      }
      else  
      { 
         //not in a match block
         linesSansPlayerScore.Add(lineIndex);
      }
    
      lineIndex++;
    }
