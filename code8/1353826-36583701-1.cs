    string rawText = System.IO.File.ReadAllText("Full path to file");
    string[] rows = rawText.Split(System.Environment.NewLine);
    List<ColumnData> data = rows
        .Select(rowText => rowText.Split(" "))
        .Select(rowArray => new ColumnData
        {
            Column1 = rowArray[0],
            Column2 = rowArray[1],
            Column3 = rowArray[2],
            Column4 = rowArray[3]
        })
        .ToList();
