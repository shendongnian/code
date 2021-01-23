    string grid = "58 96 69 22 \n" +
        "87 54 21 36 \n" +
        "02 26 08 15 \n" +
        "88 09 12 45";
    
    var lines = grid.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim().Split(' ')).ToArray();
    
    int numberOfRows = lines.Length;
    int maxNumberOfColumns = lines.Max(x => x.Length);
    string[,] separatedGrid = new string[numberOfRows, maxNumberOfColumns];
    
    for (int i = 0; i < lines.Count(); i++)
    {
        string[] values = lines.ElementAt(i);
        for (int j = 0; j < values.Length; j++)
        {
            separatedGrid.SetValue(values[j], i, j);
        }
    }
