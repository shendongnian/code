    var matrix = new int[4, 4]
    {
        { 9, 1, 2, 0 },
        { 1, 5, 2, 5 },
        { 7, 1, 6, 3 },
        { 4, 3, 2, 7 }
    };
    
    for (int i = 0; i < 4; i++)
    {
        var row = Enumerable.Range(0, 4).Select(x => matrix[i, x]);
        if (row.Distinct().Count() != 4)
            Console.WriteLine("Duplicated value in row {0} : {1}", 
                i + 1, string.Join(", ", row));
    }
    
    for (int i = 0; i < 4; i++)
    {
        var column = Enumerable.Range(0, 4).Select(x => matrix[x, i]);
        if (column.Distinct().Count() != 4)
            Console.WriteLine("Duplicated value in column {0} : {1}", 
                i + 1, string.Join(", ", column));
    }
