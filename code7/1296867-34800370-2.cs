    public int[,] ReadData(string filePath, int xDimension, int yDimension)
    {
        var results = new int[xDimension, yDimension];
        var lines = File.ReadLines(filePath);
        for (var i = 0; i < allLines.Count(); i++)
        {
            var values = lines[i].Split(new[] { ' ' }, 
                                        StringSplitOptions.RemoveEmptyEntries);
            for (var j = 0; j < values.Count(); j++)
            {
                var parsed = int.TryParse(values[j], out results[i, j]);
                if (!parsed) { }
            }
        }
        
        return results;
    }
