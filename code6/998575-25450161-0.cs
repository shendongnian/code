    public string getAge(string Name) 
        {
            connection con = new connection(); //The object for the class with the connection string 
            con.conopen(); //opens the connection
            string Age = "";
            MySqlCommand cmd_getAge = new MySqlCommand("Select Age from profile where Name = '" + Name + "';", con.con); 
            MySqlDataReader Reader = cmd_getAge.ExecuteReader();
            if (Reader.HasRows)
            {
                try
                {
                    while (Reader.Read())
                    {
                        Age = Reader.GetString(0);
                    }
                }
                finally
                {
                    Reader.Close();
                    con.conclose();
                }
            }
            return Age;
        }
