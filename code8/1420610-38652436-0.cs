    string query = @"UPDATE Variable_fields 
                     SET [This column]= @this,
                         [That column]=@that
                     WHERE ([Tranx_ID]=@trans";
    using(OleDbConnection con = new OleDbConnection(....constringhere....))
    using(OleDbCommand cmd = new OleDbCommand(query, con))
    {
       con.Open();
       cmd.Parameters.Add("@this", OleDbType.VarWChar).Value = thisTextBox.Text;
       cmd.Parameters.Add("@that", OleDbType.VarWChar).Value = thatTextBox.Text;
       cmd.Parameters.Add("@trans", OleDbType.VarWChar).Value = transTextBox.Text;
       int rowsInserted = cmd.ExecuteNonQuery();
       if(rowsInserted > 0)
           MessageBox.Show("Record added");
       else
           MessageBox.Show("Record NOT added");
    }
