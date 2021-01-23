    private bool validateUser(string username, string password)
    {
        if (UserName != "" & Password != "")
        {
            server = "localhost";
            database = "test";
            uid = "username";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection con = new MySqlConnection(connectionString);
            // MySqlConnection con = new MySqlConnection(@"Data Source=USER;Initial Catalog=admin;Integrated Security=True"); 
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT COUNT(*) FROM table1 WHERE username='" + UserName + "' AND password='" + Password + "'", con);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                
                MessageBox.Show("connected");
            }
            else
                MessageBox.Show("Invalid username or password");
            }
            // we need to try and get the database to this method
        User validatedUser = userList.FirstOrDefault( user => user.UserName.Equals( UserName ) && user.Password.Equals( Password ));
        return validatedUser != null; //This is where it works, but doesn't pull from the processes above because of inheritance
    }
