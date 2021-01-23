    for (int i = myDataTable.Rows.Count - 1; i >= 0; i--)
    {
        DataRow row = myDataTable.Rows[i];  //Remove
        if (myDataTable.Rows[i][0].ToString() == string.Empty)
        {
            myDataTable.Rows.Remove(row);
        }
    }
