    string[] Lines = File.ReadAllLines(f.File);
    for (int i = 3; i < Lines.Length-3; i += 7)
    {
      for (int j = 0; j < 3; j++)
      {
        string[] readLineSplit = Line [i+j].Split('|');
        etc..
      }
    }
