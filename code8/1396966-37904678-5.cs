    int[,] matrix = null;
    int rowCount = 0;
    int colCount = 0;
    var lines = File.ReadAllLines(path);
    rowCount = lines.Length;
    for(int i = 0; i < rowCount; i++) {
        var line = lines[i];
        var tokens = line.Split(new []{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);        
        if(matrix == null) {
            colCount = tokens.Length;
            matrix = new int[rowCount, colCount];
        }
        for(int j = 0; j < colCount; j++) {
            matrix[i, j] = int.Parse(tokens[j]);
        }
    }
    //this part is for display the matrix
     int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
   
