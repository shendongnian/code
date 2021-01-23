    List<string[]> lines = new List<string[]>();
    while (!file.EndOfStream)
    {
         string line = file.ReadLine();
         if (!String.IsNullOrWhiteSpace(line))
         {
             lines.Add(line.Split(',');   
         }
    }
    string[][] FP_GamesArray = lines.ToArray();
