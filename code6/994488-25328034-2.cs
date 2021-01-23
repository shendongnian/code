    var userName = l.UsernameInput.Text;
    Task.Run<string>(() => 
    {
        using (var cmd = new OleDbCommand(con))
        {
            cmd.CommandText = "SELECT [secretcode] FROM UsrDet WHERE usrname = @username";
            cmd.Parameters.AddWithValue("@username", userName);
            con.Open();
            using (var dr = cmd.ExecuteReader())
            {
                while(dr.Read())
                {
                    return dr["secretcode"].ToString();
                }   
            }
        }
    }).ContinueWith((t) => 
    {
        // update UI
        seccode.Visible = true;
        seccode.Text = t.Result;
    }, TaskScheduler.FromCurrentSynchronizationContext());
