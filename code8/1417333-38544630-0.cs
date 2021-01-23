    string grid = "58 96 69 22 \n" +
        "87 54 21 36 \n" +
        "02 26 08 15 \n" +
        "88 09 12 45";
    
    var lines = grid.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
    
    string[,] gridArray = new string[lines.Count(), 4];
    
    for (int line = 0; line < lines.Length; line++)
    {
        string[] values = lines[line].Trim().Split(' ');
    
        for(int val = 0; val < values.Length; val++)
        {
            gridArray.SetValue(values[val], line, val);
        }
    }
