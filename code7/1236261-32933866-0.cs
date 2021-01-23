    {
        ...
        // open db connection
        con.Open();
        // get our own asset adapter
        Da = new AssetAdapter(con);
        // create a DataTable and fill it.
        DataTable assets = new DataTable();
        Da.Fill(assets);
        // add a RowDeleted event handler for the table.
        assets.RowDeleted += new DataRowChangeEventHandler(row_deleted);
        . . . you could define handlers for update and insert as well . . .
        // insert a test record
        DataRow assetRow = assets.NewRow();
        assetRow["asset_floor"] = "15";
        assetRow["asset_room"] = "7c";
        . . . and so on . . .
        assets.Rows.Add(assetRow);
        // update database.
        Da.Update(assetRow);
        // now get the asset id of the new created asset
        Int32 assetID = (Int32)Da.InsertCommand.Parameters["@Identity"].Value;
        // now we can use this id to delete the row again
        DataRow found = assets.Rows.Find(assetID);
        if (found != null) 
        {
            // now delete row again
            assets.Rows.Delete(assetID);
            Da.Update(assets)
        }
    
        con.Close();
        
        this.Close();
        ...
    }
    /**
    * AssetAdapter returns the database adapter for selecting and deleting
    */
    public static OleDbDataAdapter AssetAdapter(OleDbConnection connection)
    {
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        OleDbCommand command;
        OleDbParameter parameter;
        /*
         * Here we create a command that selects assets by
         * floor and room. You can add more fields if needed.
         * Finally the command is set as the adapters *SelectCommand*
         */
        command = new OleDbCommand("SELECT asset_id FROM tbl_Assets " +
            "WHERE asset_floor = ? AND asset_room = ?", connection);
        // add the parameters floor and room
        // (assuming VarChar is your field type, change accordingly) 
        command.Parameters.Add("asset_floor", OleDbType.VarChar, 20);
        command.Parameters.Add("asset_room", OleDbType.VarChar, 20);
        // finally set the command to the adapters select command
        dataAdapter.SelectCommand = command;
        /*
         * Now we create a command that inserts assets by
         * filling the fields needed.
         * Then the command is set as the adapters *InsertCommand*
         */
        // Create the InsertCommand.
        command = new OleDbCommand(
            "INSERT INTO tbl_Assets (asset_floor, asset_room, asset_description, asset_createdOn) " +
            "VALUES (?, ?, ?, ?)", connection);
        // add the parameters
        command.Parameters.Add(
            "asset_floor", OleDbType.VarChar, 20, "asset_floor");
        command.Parameters.Add(
            "asset_room", OleDbType.VarChar, 20, "asset_room");
        command.Parameters.Add(
            "asset_description", OleDbType.VarChar, 128, "asset_description");
        command.Parameters.Add(
            "asset_createdOn", OleDbType.DateTime, 20, "asset_createdOn");
        // create an output parameter for the new identity value.
        parameter = command.Parameters.Add("@Identity", SqlDbType.Int, 0, "asset_id");
        parameter.Direction = ParameterDirection.Output;
        // now we set the command to the adapters insert
        adapter.InsertCommand = command;
        . . .
            // same procedure for UpdateCommand
        . . .
        /*
         * Here we create a command that deletes assets by
         * asset_id. You can add more fields if needed.
         * Finally the command is set as the adapters *DeleteCommand*
         */
        // Create the DeleteCommand.
        command = new OleDbCommand(
            "DELETE * FROM tbl_Assets WHERE asset_id = ?", 
            connection);
        parameter = command.Parameters.Add(
            "asset_id", OleDbType.Char, 5, "asset_id");
        parameter.SourceVersion = DataRowVersion.Original;
        dataAdapter.DeleteCommand = command;
        return dataAdapter;
    }
    // event handler which is called when row is deleted
    private static void row_deleted(object sender, DataRowChangeEventArgs e)
    {
        Console.WriteLine("Row was DELETED event: name={0}/{1}; action={2}", 
            e.Row["asset_floor", DataRowVersion.Original], 
            e.Row["asset_room", DataRowVersion.Original], 
            e.Action);
    }
