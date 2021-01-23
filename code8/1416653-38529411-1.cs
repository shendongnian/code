    public void MoveRows(DataTable src, DataTable dest, DataRow[] rows)
    {
        foreach (DataRow row in rows)
        {
            // create empty row
            DataRow newrow = dest.NewRow();
            // copy data
            newrow.ItemArray = row.ItemArray;
            // add to dest
            dest.Rows.Add(newrow.ItemArray);
            // remove from src
            src.Rows.Remove(row);
        }
    }
