    // ...
    var validLogin = false;
    using (SqlCeConnection con = new SqlCeConnection(
        "Data Source=" +
            System.IO.Path.Combine(
                Path.GetDirectoryName(
                    System.Reflection.Assembly.GetEntryAssembly().Location),
        "INCdb.sdf"))) 
    {
        con.Open();
        SqlCeCommand cmd = con.CreateCommand();
        cmd.CommandText =
                "SELECT COUNT(*) FROM LoginTB Where username=@user1 AND password=@pass1";
        cmd.Parameters.AddWithValue("@user1", UserTxt.Text.Trim());
        cmd.Parameters.AddWithValue("@pass1", PassTxt.Text.Trim());
        cmd.CommandType = CommandType.Text;
        validlogin = ((int)cmd.ExecuteScalar()) > 0;
    }
    MessageBox.Show(validlogin.ToString());
    // ...
