    try
    {
        using(OleDbConnection connection = new OleDbConnection(.....))
        using(OleDbCommand command = new OleDbCommand(cb, connection))
        {
            connection.Open();
            string cb = @"UPDATE book SET [Location] = 'lib' 
                          WHERE [Book_Id]= ?";
            command.Parameters.Add("@p1", OleDbDataType.VarWChar).Value = textbookid.Text;
            int rowsUpdated = command.ExecuteNonQuery();
            if(rowsUpdated > 0)
                 MessageBox.Show("Successfully returned", ....);
            else
                 MessageBox.Show("Selection Error."); 
         }
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message); 
    }
