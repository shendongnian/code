    for(int i = 0; i < pendingdataGridView.Rows.Count; i++)
    {
        if(!pendingdataGridView.Rows.Selected[i])
            Continue;
        StrQuery= @"INSERT INTO tableName VALUES (" 
                    + pendingdataGridView.Rows[i].Cells["ColumnName"].Value +", " 
                    + pendingdataGridView.Rows[i].Cells["ColumnName"].Value +");";
        comm.CommandText = StrQuery;
        comm.ExecuteNonQuery();
    }
