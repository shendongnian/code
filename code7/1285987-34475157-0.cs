    string finalJSON = "";
    try
    {
       connection.Open();
       command = new SqlCommand(sql, connection);
       SqlDataReader read = command.ExecuteReader();
       
       // Create a new object that matches the structure of the JSON file.
       var root = new RootObject
       {
           DATA = new DATA { clocked = new List<Clocked>() }
       };
       
       while (read.Read())
       {
          root.DATA.firstName = read["firstName"].ToString();
          root.DATA.lastName = read["lastName"].ToString();
          // Continue with the other attributes...
          root.DATA.clocked.Add(new Clocked {date = read["date"].ToString(), type = read["type"].ToString() });
       }
       // Serialize the object using JSON.Net.
       finalJSON = JsonConvert.SerializeObject(root);
       read.Close();
       command.Dispose();
       connection.Close();
    }
