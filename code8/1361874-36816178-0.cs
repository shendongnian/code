     protected void btnSignIN_Click(object sender, EventArgs e)
    {
        string str = "Data Source=(LocalDB)\\MSSQLLocalDB;";
        str += "AttachDbFilename=|DataDirectory|Database.mdf;";
        str += "Integrated Security= True";
        string userName = txtUserNameLogIN.Text;
        string password = txtPasswordLogIN.Text;
        SqlConnection c = new SqlConnection(str);
        SqlCommand cmd = new SqlCommand("SELECT UserName FROM [Table] WHERE UserName=@userName", c);
        SqlDataReader reader = cmd.ExecuteReader();
    if (reader.Read())
                MessageBox.Show("connected");
            else
                MessageBox.Show("failed to connect");
            c.Close();
    }
