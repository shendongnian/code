    SqlCommand cmdd = new SqlCommand();
    cmdd.CommandText = "select top 1 Id from [users] where username=@username";
    cmdd.Parameters.AddWithValue("@username",username);
    cmdd.Connection = conn;
    SqlDataReader rd = cmdd.ExecuteReader();
    var userId = 0;
    if(rd.Read())
    {
        userId = (int)rd[0];
    }
    conn.Close();
    if (userId == 0)
    {
        Label1.Visible = true;
        Label1.Text = "User does not exist";
        return;
    }
    else
       .... // userId holds the users Id
       ...
       cmd.Parameters.AddWithValue("@to", userId);
