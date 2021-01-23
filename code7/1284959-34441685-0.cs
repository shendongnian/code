    string cmdText = "INSERT INTO TotalPlayerName ([Player Name]) VALUES(?)";
    using(OleDbConnection connection = new OleDbConnection(...))
    using(OleDbCommand command = new OleDbCommand(cmdText, connection))
    {
       connection.Open();
       command.Parameters.Add("@p1", OleDbType.VarWChar).Value = textBox[i].Text;
       int result = command.ExecuteNonQuery();
       if(result > 0)
          MessageBox.Show("Record Inserted");
       else
          MessageBox.Show("Failure to insert");
    }
