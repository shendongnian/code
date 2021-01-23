    int[][] matrix = null;
    int rowCount = 0;
    int colCount = 0;
    string lines = File.ReadAllLines(path);
    rowCount = lines.Length;
    for(int i = 0; i < rowCount; i++) {
        var line = lines[i];
        var tokens = line.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
        colCount = token.Length;
        if(matrix == null) {
            matrix = new int[rowCount][colCount];
        }
        for(int j = 0; j < colCount) {
            matric[i][j] = int.Parse(token[j]);
        }
    }
