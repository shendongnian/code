    int countOne = 0;
    for (int x = 0; x < dataTable.Rows.Count; x++)
    {
        for (int y = 0; y <= 3; y++)
        {
            arrayE[countOne + y].Text = dataTable.Rows[x][y].ToString().Trim();
        }
        countOne += 4;
    }
