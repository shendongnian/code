    SqlCeConnection _cnt = new SqlCeConnection();
    _cnt.ConnectionString = "Your Connection String";
    SqlCeCommand _cmd = new SqlCeCommand();
    _cmd.Connection = _cnt;
    _cmd.CommandType = System.Data.CommandType.Text;
    _cmd.CommandText = "SELECT id FROM myTable where Category=@Name";
    sqlCommand.Parameters.AddWithValue("@Name", newCatTitle);
    _cnt.Open();
    var idTemp = _cmd.ExecuteScalar();
    
    _cmd.Dispose();
    _cnt.Close();
    _cnt.Dispose();
    if (idTemp == null)
    {
      //Insert into table
    }
    else
    {
      //Message it already exists
    }
