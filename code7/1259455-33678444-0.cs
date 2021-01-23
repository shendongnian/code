        public bool saveRecord(string Firstname,string Lastname,string Username,string Password,string Emailadress)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
               throw new ArgumentException(FirstName, "FirstName cannot be null");
            // Do the same for the other args...
            using (MySqlConnection connection = new MySqlConnection("Server=localhost;Port=8889;Database=SSC;Uid=root;Password=root"))
            {
                try
                {
                    string Sql_Query = "INSERT INTO administrator (Firstname,Lastname,Username,Password,EmailAdress)VALUES(@Firstname,@Lastname,@Username,@Password,@EmailAdress);";
                    connection.Open();    
    
                    using (MySqlCommand command = new MySqlCommand(Sql_Query, connection))
                    {
    
                        command.Parameters.AddWithValue("@Firstname", Firstname);
                        command.Parameters.AddWithValue("@Lastname", Lastname);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@EmailAdress", Emailadress);
    
                        command.ExecuteNonQuery();
                        MessageBox.Show("Inserted");
    
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
             }
         }
