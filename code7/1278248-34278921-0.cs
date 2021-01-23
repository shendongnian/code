    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        if (!CheckLogin(txtLogin.Text.ToString().Trim()))
        {
            //Register the user
        }
        else
        {
            lblLoginAvailable.Visible = true;
            lblLoginAvailable.Text = "This login already exists in our system. Chooce another login please";
        }
    }
    protected bool CheckLogin(string login)
    {
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("select id from users where lower(login) = lower(@login)", con);
        cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
        string id = "";
        try
        {
            con.Open();
            id = cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            //...
        }
        finally
        {
            con.Close();
        }
        if (String.IsNullOrEmpty(id)) return false;
        return true;
    }
