    var tab = new Table();
    for (var z = 0; z < 2; z++)
    {
        var tr = new TableRow();
    
        for (var j = 0; j < 2; j++)
        {
           var tc = new TableCell();
           tc.Append(new Paragraph(new Run(new Text("i: " + z + " j:" + j))));
           tr.Append(tc);
        }
        tab.Append(tr);
    }
