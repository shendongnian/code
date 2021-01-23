    string[] columns = { "SomeColumnA", "SomeColumnB", "SomeColumnC" };
    var gridColumns = columns.Select(c => grid.Columns[c]).Where(c => c != null);
    foreach (var col in gridColumns)
    {
        // you could use a switch if you need to set different things according to the Name
        switch (col.Name)
        {
            case "SomeColumnA": col.Width = 100; break;
            case "SomeColumnB": col.Width = 120; break;
            case "SomeColumnC": col.Width = 150; break;
            default: break;
        }
    }
