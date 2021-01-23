    using(MySqlConnection connection = new MySqlConnection(MySQLConnection))
    {    
       connection.Open();            
       MySqlCommand cmd = connection.CreateCommand();
       cmd.CommandText = "SELECT * FROM users WHERE nick=@nick AND password=@pass LIMIT 1;";
       cmd.Parameters.AddWithValue("@nick", nick.Text);
       cmd.Parameters.AddWithValue("@pass", pass.Text);
       using(MySqlDataReader dataReader = cmd.ExecuteReader())
       {            
            if (dataReader.HasRows)
            {
                int id;
                label3.Text = "Loged.";
                dataReader.Read();
                id = Convert.ToInt32(dataReader[0]);
                game g = new game();
                g.label1.Text = Convert.ToString(dataReader[1]);
                g.label84.Text = Convert.ToString(id);
                this.Hide();
                g.Show();
            }
            else
            {
                label3.Text = "Bad information.";
            }
        }
    }
