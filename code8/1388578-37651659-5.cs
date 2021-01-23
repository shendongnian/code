    public string Insert()
    {
        // Assuming Name email and passwords are global variables
        // Or else need to get them
        string conStr = @"Data Source=ZARAK\SQLEXPRESS;Initial Catalog=ProjectDAL;integrated security=true";
        int queryResult = 0;
        try
        {
            string querySQL = "Insert INTO tbl_User(Name,Email,Password)VALUES(@name,@email,@password)";
            using (SqlConnection Conn = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(querySQL, Conn))
                {
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = Name;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                   queryResult= cmd.ExecuteNonQuery();
                }
            }
            return queryResult + "Record/s Inserted successfully!";
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                return "Record Already Exists";
            }
            return "Some other error";
        }           
    }
 
   
