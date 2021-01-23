    void Filter()
    {
        Object[,] mybaseobject = new object[,]
        { 
            { "Ranjith", "Murthy" }, 
            { "Rohith", "M" }, 
            { "Ranjith","Murthy" }, 
            { "varsha", "MJ" }
        };
        
        var objectList = AsList(mybaseobject);
        
        var distinctLines = new List<object[]>();
        
        foreach (var line in objectList)
        {
            if (!distinctLines.Any(x => x.SequenceEqual(line)))
            {
                distinctLines.Add(line);
            }
        }
        
        var filteredobjects = AsTwoDimentionalArray(distinctLines);
    }
    private List<object[]> AsList(object[,] input)
    {
        var lines = new List<object[]>();
        for(var i = 0; i < input.GetLength(0);++i)
        {
            var line = new List<object>( input.GetLength(1));
            for (var j = 0; j < input.GetLength(1); ++j)
            {
                line.Add(input[i, j]);
            }
            lines.Add(line.ToArray());
        }
        return lines;
    }
    
    private object[,] AsTwoDimentionalArray(List<object[]> input)
    {
        var result = new object[input.Count(), input[0].Length];
        for (var i = 0; i < input.Count; ++i)
        {
            for(var j = 0; j < input[0].Length; ++j)
            {
                result[i, j] = input[i][j];
            }
        }
        return result;
    }
    
