    var queryEF = dbContext.Test
                           .Where(t => t.Line.Contains(";" + value" + ";");
    var queryMemory = queryEF.AsEnumerable()   // shift to Linq-to-Objects
                             .Where((t => Array.IndexOf(t.Line.Split(';'), value) == 1);
    if (queryMemory.Any())
    {
        //Do something ...
    }
