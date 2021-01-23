    protected void Button1_Click(object sender, EventArgs e)
    {
        conn.Open();
        string SQL = "select UserID from [User] where UserName=@UserName AND Password=@Password"; 
        SqlCommand com = new SqlCommand(checkuser, conn);
        com.Parameters.AddWithValue("@UserName", TextBoxUN.Text);
        com.Parameters.AddWithValue("@Password", TextBoxPass.Text);
        SqlDataReader data = com.ExecuteReader();
        if (data.HasRows) // username and password match
        {
            conn.Close();
            Response.Redirect("Registration.aspx");
        }
        else
        {
            conn.Close();
            // display error here
        }
    }
