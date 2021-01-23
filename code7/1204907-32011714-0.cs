    SqlCommand cmd = new SqlCommand("select * from Users where username='" +txtUsername.Text + "' and password='" + txtPassword.Text + "' ", con);
    con.Open();
    SqlDataReader dr = default(SqlDataReader);
    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    while ((dr.Read()) == true)
    {
       lbluser.Text = dr["UserName"].ToString();
       lblpwd.Text = dr["password"].ToString();
    if ((txtUsername.Text.Trim() == lbluser.Text.Trim())  &(txtPassword.Text.Trim() == lblpwd.Text.Trim()))
            {
                Response.Redirect("nextpage.aspx");
            }
            else
            {
                lblerrormessage.Visible = true;
            }
        }
       dr.Close();
    con.Close();
