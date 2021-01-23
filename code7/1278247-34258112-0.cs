    protected void txtUserName_TextChanged(object sender, EventArgs e){
        string constr = WebConfigurationManager.ConnectionStrings["your_con_string_name"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("select id from Job_UserData where lower(username) = lower(@Usn)", con);
        //your code will not work, if you have in database UserName = "login", but user write it as "Login", because your sql-query is case sensitive
        cmd.Parameters.AddWithValue("@Usn", txtUserName.Text);
        bool is_exists = false;
        try{
            con.Open();
            is_exists = cmd.ExecuteScalar() == null ? false : true;
        }
        catch(Exception ex){
            //if you will work with exceptions. But they will not be =)
        }
        finally{
            con.Close();
        }
        if (is_exists)
        {
            someLabelBelowTheTextBox.Text = "This UserName is already exists. Please Choose another one";
            txtUserName.Focus();
        }
    }
