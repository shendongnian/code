    string str1 = "INSERT INTO Cars(Name) VALUES ('Pagani')";
    string str2 = "Select @@Identity";
    int ID;
    using (OleDbConnection conn = new OleDbConnection(connect))
    {
      using (OleDbCommand cmd = new OleDbCommand(str1, conn))
      {
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.CommandText = str2;
        ID = (int)cmd.ExecuteScalar();
      }
    }
