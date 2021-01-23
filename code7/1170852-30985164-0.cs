    SqlCommand cmd = new SqlCommand(@"SELECT Category FROM Logins
                                WHERE Username=@uname and
                                Password=@pass", con);
    cmd.Parameters.AddWithValue("@uname", textBox_usern.Text);
    cmd.Parameters.AddWithValue("@pass", textBox_pwd.Text);
    int result = (int)cmd.ExecuteReader();
    SqlDataReader reader = cmd.ExecuteReader();
    if (reader.Read())
    {
    var c = reader["Category"];
       if (c== "Admin")//this one will chek whether user is admin or user
        {
            MessageBox.Show("Welcome Admin");
            Admin f1 = new Admin();
            f1.Show();
        }
        else
        {
            MessageBox.Show("Welcome " + textBox_usern.Text);
            FormCheck f3 = new FormCheck();
            f3.Show();
        }
    }
    else
    {
        MessageBox.Show("Incorrect login");
    }
    textBox_usern.Clear();
    textBox_pwd.Clear();
