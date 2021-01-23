        SqlCommand cmd;
        SqlDataReader dr;
        string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        string name = "Joe";
        SqlConnection cnn = new SqlConnection(ConnectionString);
        cmd = new SqlCommand("Select * from t_Users WHERE Name=@name or FullName like @fullname", cnn);
        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
        cmd.Parameters.Add("@fullname", SqlDbType.VarChar).Value = name + "%";
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
        }
