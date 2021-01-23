    protected void Button6_Click(object sender, EventArgs e)
    {
        Random rnd = new Random();
        string resetpassword = rnd.Next(5000, 100000).ToString();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HealthDBContext"].ConnectionString);
        conn.Open();
        string reset = "UPDATE Users SET" + " Password=@pass" + " WHERE UserName=@user";
        SqlCommand com = new SqlCommand(reset, conn);
        com.Parameters.AddWithValue("@pass", resetpassword);
        com.Parameters.AddWithValue("@user", TextBox1.Text);
        com.ExecuteNonQuery();
        conn.Close();
    }
