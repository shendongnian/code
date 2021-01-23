    int colIndex = -1;
    for (int i = 0; i < dataGridView1.Columns.Count; i++)
    {
        if (dataGridView1.Columns[i].Name.Equals("Hersteller"))
        {
            colIndex = i;
            break;
        }
    }
    if (colIndex > -1)
        // Found the column, do something
