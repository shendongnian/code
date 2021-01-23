       private void main_B_login_Click(object sender, RoutedEventArgs e)
    {
        //connect to the database
        SqlConnection loginConn = null;
        SqlCommand cmd = null;
        SqlDataAdapter sda = null;
        DataTable dt = new DataTable();
        loginConn = new SqlConnection("server=localhost;" + "Trusted_Connection=yes;" + "database=Production; " + "connection timeout=30");
        cmd = new SqlCommand("Select Username, Password FROM [User] WHERE Username =@UsernameValue", loginConn);
        loginConn.Open();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UsernameValue", SqlDbType.VarChar).Value = Main_T_Username.Text;
        sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]['Password'] == Main_T_Password.Text)
                {
                    MessageBox.Show("username and Password = Correct");
                }
                else
                {
                    MessageBox.Show("Password = Wrong");
                }
             }
            else
            {
                MessageBox.Show("WrongPass or Username!");
                
            }
            loginConn.Close();
        }
