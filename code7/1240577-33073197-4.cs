    public User selectQuery(string query)
    {
        User myuser = new User();
        //use this if you want to create a List of users and change the method type to "List<User>" and the return to userList.
        List<User> userList = new List<User> ();
        if (this.openDbConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, this.connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            // read the data and store it in the list
            while (dr.Read())
            {
                myuser.first_name = dr["first_name"] + "";
                myuser.last_name= dr["last_name"] + "");
                myuser.username = dr["username"] + "");
                myuser.password = dr["password"] + "");
                //use the below line only if you are expecting to return multiple users
                userList.Add(myuser);
            }
            // close reading the data operator
            dr.Close();
            // close connection
            this.connection.Close();
            // return the list of results to be displayed
            return myuser;
        }
        else
        {
            return myuser;
        }
    }
