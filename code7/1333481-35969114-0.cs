    using(var connection = new OleDbConnection(conString))
    using(var cmd = connection.CreateCommand())
    {
        cmd.CommandText = "INSERT INTO IntNotes (Room, [Size]) VALUES(?, ?)";
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRoom.Text;
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtSize.Text;
        // I assume your column types mapped with VarWChar
       
        connection.Open();
        int effectedRows = cmd.ExecuteNonQuery();
        if(effectedRows > 0)
        {
           MessageBox.Show("Room is Added");
        }   
    }
