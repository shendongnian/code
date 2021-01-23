    int i = 1;
    TableRow row = new TableRow();
    foreach (DataRow dr2 in dt.Rows)
    {
        if (i == 1)
            row = new TableRow();
        // .. further processing
        i++;
        if (i > 4)
            i = 1;
    }
