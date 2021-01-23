    int progs;
    string Command = @"select * from clientprogram where clientProgClientID =     @clientID;";
    using (MySqlConnection mConnection = new MySqlConnection(mycon))
    {
     mConnection.Open();
     using (MySqlCommand cmd2 = new MySqlCommand(Command, mConnection))
      {
          cmd2.Parameters.Add(new MySqlParameter("@clientID", lblcID.Text));
          using (MySqlDataReader reader = cmd2.ExecuteReader())
          {
                while (reader.Read()) // CHANGE TO THIS
                {
                     progs = (int)reader["clientProgramID"];
                     cmbProgram.Items.Add(progs);
                }
          }
     }
     mConnection.Close();
}
