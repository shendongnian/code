    r1 = cmd2.ExecuteReader();
    if ( r1.HasRows )
    {
        r1.Read();
        Label5.Text = r1["Course_Title"].ToString();
        Label6.Text = r1["Description"].ToString();
    }
    else
    {
        Label5.Text = "";
        Label6.Text = "";
    }
