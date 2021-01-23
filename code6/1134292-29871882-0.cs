    List<int> rowIndices = new List<int>();
    for(int i = 0; i < dataTable.Rows.Count - 1; i++)
    {
        int some_field = dataTable.Rows[i].Field<int>("some_field");
        if (some_field == 123)
            rowIndices.Add(i + rowIndices.Count); // indices will increases by count
    }
    foreach(int index in rowIndices)
    {
        DataRow newRow = ....
        dataTable.Rows.InsertAt(newRow, index);
    }
