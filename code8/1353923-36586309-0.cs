    private void xButton1_Click(object sender, EventArgs e)
    {
        string userName = UserText.Text.Trim();
        string passwrd = PassText.Text.Trim();
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mohamed\Documents\UserData.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From dbo.[LOGIN] where username='" + userName + "' and Password ='" + passwrd  + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
