    SqlConnection con = new SqlConnection("Your ConnectionString");
    con.Open();
    SqlCommand cmd = new SqlCommand("select * from [login] where UserName=@Name",con);
    cmd.Parameters.AddWithValue("@Name", txtUsername.Text);
    SqlDataReader dr = cmd.ExecuteReader();
    if (dr.HasRows)
    {
       // "UserName Already Taken";
     }
    else
    {
      //"UserName Available";
    }
