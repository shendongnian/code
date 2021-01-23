    void Insert_New_Log(int startfloor, int endfloor, string currentAction)
    {
        OleDbConnection conn = new OleDbConnection(dbconnection);
        OleDbCommand comm = new OleDbCommand(dbcommand, conn);
        OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
        OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
       // adapter.UpdateCommand = builder.GetUpdateCommand();
        conn.Open();
        adapter.Fill(ds, "ElevatorTable");        
        DataRow newRow = ds.Tables[0].NewRow();
        newRow["ID"] = 0;
        newRow["Date1"] = dateAndTime;
        newRow["StartingFloor"] = startfloor;
        newRow["EndFloor"] = endfloor;
        newRow["Action"] = currentAction;
        ds.Tables[0].Rows.Add(newRow);
        DataSet dataSetChanges = ds.GetChanges();
        ds.AcceptChanges();
        try
        {
            adapter.Update(dataSetChanges, "ElevatorTable");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally { conn.Close(); }
        //update Visible list
        dbListBox.Items.Clear();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            dbListBox.Items.Add(row["ID"] + "\t" + row["Date1"] + "\t" + row["StartingFloor"] + "\t" + row["EndFloor"] + "\t" + " (" + row["Action"] + ")");
        }
    }
