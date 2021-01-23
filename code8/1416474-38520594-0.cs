        string connString = "Data Source=MCDU11;Initial Catalog=VisitorManagement;Integrated Security=True";
    
        SqlCommand cmd = new SqlCommand("SELECT * FROM SecurityUser WHERE Username = '" + txtUsername.Text.Trim() + "' AND "
                                            + "Password='" + Encrypt(txtPassword.Text.Trim()) + "'" , conn);
    
        SqlCommand cmd1 = new SqlCommand("update SecurityUser set LoginOn ='" + DateTime.Now + "' , " + "WHERE Username ='" + txtUsername.Text.Trim() + "'", conn);
       using (SqlConnection conn = new SqlConnection(connString))  
    {
    
        using (SqlDataAdapter a = new SqlDataAdapter(
    		    cmd, conn))
        {
                    DataTable t = new DataTable();
        		    a.Fill(t);
    
           if (t.Rows.Count > 0)
           {
    
            Session["Username"] = txtUsername.Text;
            Session["Id"] = t[0]["Id"].ToString();
            cmd1.ExecuteNonQuery();
            Response.Redirect("SecurityHome.aspx");
    
           }
           else
           {
            lblError.Text = "Either username and/or password is wrong. Please try again!";
           }
    
       }
    
       }
