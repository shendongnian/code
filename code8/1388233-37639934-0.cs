    string cmdText = @"SELECT *
                       FROM UserData
                       INNER JOIN HotelData 
                          ON (UserData.Username = HotelData.Username) 
                       WHERE UserData.UserName = @user";
    using(SqlConnection con = new SqlConnection(@"....."))
    using(SqlCommand cmd = new SqlCommand(cmdText, con);
    {
        con.Open();
        cmd.Parameters.Add("@user", SqlDbType.NVarChar).Value = UserName;
        using(SqlDataReader dr = cmd.ExecuteReader())
        {
            // Now this will loop just one time, only for the logged in user
            while (dr.Read())
            {
               ....
            }
        }
    }
