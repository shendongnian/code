    <asp:Label ID="lbluser" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblpwd" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblmessage" runat="server"  Visible="false" Text="Incorrect Username and Password"></asp:Label>
----------
 
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
                lblmessage.Visible = true;
            }
        }
       dr.Close();
    con.Close();
