    // Parse
    var rows = File.ReadAllLines(filePath).Select(l => l.Split(',')).ToArray();
    
    ConcurrentDictionary<int, int[]> fileLoading = new ConcurrentDictionary<int, int[]>();
    
    // Iterate through each column (skipping the date column)
    for (int c = 1; c < rows[0].Length; c++)
    {  
        // Column header
        int column = Int32.Parse(rows[0][c]);
        
        // Column values
        fileLoading[column] = rows.Skip(1).Select(r => Int32.Parse(r[c])).ToArray();
    }
