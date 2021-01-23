    private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string xlsSheet = "PR$";
            
            DataTable dt = (DataTable)dgPR.DataSource;
            string changeColumns = "";
            for (int i = 0; i < Table.ColumnName.Count; i++)
            {
                changeColumns += "[" + Table.ColumnName[i] + "]"+ "=@" + Table.ColumnName[i].Replace(' ','_');
                if (Table.ColumnName.Count - 1 != i)
                    changeColumns += ",";
            }
            adap.UpdateCommand = new OleDbCommand("UPDATE [" + xlsSheet + "]  SET " + changeColumns +
                                                                " WHERE " + "["+ Table.ColumnName[PrimaryColumnIndex] +
                                                                "]"+ " = @" + Table.ColumnName[PrimaryColumnIndex].Replace(' ','_'), conn);
            for (int i = 0; i < Table.ColumnName.Count; i++)
            {
                adap.UpdateCommand.Parameters.Add("@" + Table.ColumnName[i].Replace(' ','_'), OleDbType.Char, 255).SourceColumn = Table.ColumnName[i];
            }
            foreach (int row in ListOfValues.Keys)
            {
                Table tbl = ListOfValues[row];
                ds.Tables[0].Rows[row][Table.ColumnName[PrimaryColumnIndex]] = ds.Tables[0].Rows[row][PrimaryColumnIndex];
                for (int i = 0; i < tbl.Value.Count; i++)
                {
                    ds.Tables[0].Rows[row][Table.ColumnName[tbl.col[i]]] = tbl.Value[i];
                }
                adap.Update(ds.Tables[0]);
            }
            conn.Close();
            MessageBox.Show("Updated");
        }
