    string name="";
    string surname="";
    using (SqlConnection Connection = new SqlConnection("..."))
    {
       Connection.Open();
       using (SqlCommand Command = Connection.CreateCommand())
       {        
          Command.CommandText = "SELECT name,surname FROM Users WHERE ID=2";
          using (SqlDataReader reader = Command.ExecuteReader())
          {
             reader.Read();
             name = reader.GetString(0);
             surname= reader.GetString(1);
          }
       }
    }
    NameTextBox.Text = name;
    SurnameTextBox.Text = surname;
