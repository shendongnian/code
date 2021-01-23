    SqlConnection _cnt = new SqlConnection();
    _cnt.ConnectionString = "Your Connection String";
    SqlCommand _cmd = new SqlCommand();
    _cmd.Connection = _cnt;
    _cmd.CommandType = System.Data.CommandType.Text;
    _cmd.CommandText = "SELECT id FROM myTable where Category=@Name";
    _cmd.Parameters.Add("@Name", string);
    _cmd.Parameters["@Name"].Value = newCatTitle;
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
