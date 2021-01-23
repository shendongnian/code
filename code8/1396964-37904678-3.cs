    int[,] matrix = null;
    int rowCount = 0;
    int colCount = 0;
    var lines = File.ReadAllLines(path);
    rowCount = lines.Length;
    for(int i = 0; i < rowCount; i++) {
        var line = lines[i];
        var tokens = line.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);        
        if(matrix == null) {
            colCount = tokens.Length;
            matrix = new int[rowCount, colCount];
        }
        for(int j = 0; j < colCount; j++) {
            matrix[i, j] = int.Parse(tokens[j]);
        }
    }
