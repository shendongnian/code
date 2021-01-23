    NewDTable.Columns.Add("Field Name");
    for (int i = 0; i < OldDTable.Rows.Count; i++)
    {
        NewDTable.Columns.Add();
    }
    for (int i = 0; i < OldDTable.Columns.Count; i++)
    {
        DataRow NewRow = NewDTable.NewRow();
        NewRow[0] = OldDTable.Columns[i].Caption;
        for (int j = 0; j < OldDTable.Rows.Count; j++)
        {
            NewRow[j + 1] = OldDTable.Rows[j][i];
        }
        NewDTable.Rows.Add(NewRow);
    }
