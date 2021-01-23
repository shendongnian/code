    public void MoveRows(DataTable src, DataTable dest, DataRow[] rows)
    {
        foreach (DataRow row in rows)
        {
            // create empty row
            DataRow newrow = dest.NewRow();
            // copy data
            newrow.ItemArray = row.ItemArray;
            // add to dest
            dest.Rows.Add(newrow);  // (*)
            // remove from src NOTE: This may or may not throw an RowNotInTableException
            // to avoid it you can skip the Remove and use the loop below instead..
            src.Rows.Remove(row);
        }
        // alternative way of removing the rows..
        //foreach (DataGridViewRow item in this.dgvUser.SelectedRows)
        //{
        //    dgvUser.Rows.RemoveAt(item.Index);
        //}
    }
