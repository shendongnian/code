    string userid, password;
    using(var cmd = new SqlCommand(sql,cnn))
    {
       cnn.Open();
       using (var reader = cmd.ExecuteReader())
       {
          reader.Read();
          userid = reader.GetString(0);
          password = reader.GetString(1);
       }
    }
