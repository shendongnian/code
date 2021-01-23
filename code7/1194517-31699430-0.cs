     List <string> IPs=new List<string>();
     MySqlConnection conn = new SqlConnection("yourconnectionstring");
     conn.Open();   
      MySqlCommand cmd = conn.CreateCommand();
      string command = "Select IP from myIPTable";
      cmd.CommandText = command;
      MySqlDataReader sqlreader = cmd.ExecuteReader();
      while (sqlreader.Read())
        {
          IPs.Add(sqlreader[0].ToString());
        }
  
