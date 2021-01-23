    var userName = l.UsernameInput.Text;
    Task.Run(() => 
    {
        con.Open();
        using (var cmd = new OleDbCommand("SELECT [secretcode] FROM UsrDet WHERE usrname = '" + userName +"';",con))
        {
            var dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                return dr["secretcode"].ToString();
            }   
        }
    }).ContinueWith((t) => 
    {
        // update UI
        seccode.Visible = true;
        seccode.Text = t.Result;
    }, TaskScheduler.FromCurrentSynchronizationContext());
