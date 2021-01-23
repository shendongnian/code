    foreach (DataRow r in myTableData.Rows)
    {
        for (int i = 1; i < myTableData.Columns.Count - 1; i+=2)
        {
            if (r[i] == r[i + 1])
            {
                // do something;
            }
        }
    
    }
