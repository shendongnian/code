    var userid;
    var password;
    using(var cmd = new SqlCommand(sql,cnn))
    {
       cnn.Open();
       using (var reader = cmd.ExecuteReader())
       {
          reader.Read();
          userid = reader[0];
          password = reader[1];
       }
    }
