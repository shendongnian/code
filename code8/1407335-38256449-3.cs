    object[][] data = new object[][]{ 
            new object[] {"kjslwe", 3, "w", 45, "erer", 643, "reew", "54", 56, 34},
            new object [] {23, "e", 1, "so", 123213, "ds", 343433}
    };
    var columns = data.Max(x => x.Count());         /* Calculate number of columns */
    grid.ColumnCount = columns;                     /* Set column count of grid   */
    data.ToList().ForEach(x => grid.Rows.Add(x));   /* Add rows                    */
