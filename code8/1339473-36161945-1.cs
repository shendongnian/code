    bool exists = false;
    // create a command to check if the username exists
    using (SqlCommand cmd1 = new SqlCommand())
    {
        cmd1.CommandText = "select count(*) from brugere where bruger_navn = @bruger_navn";
        cmd1.Connection = conn;
        cmd1.Parameters.AddWithValue("bruger_navn", txtUsername.Text);
        exists = (int)cmd1.ExecuteScalar() > 0;
    }
    // if exists, show a message error
    if (exists)
       Label1. Text = "This username has been using by another user."; 
    else
    {
        // does not exists, so, persist the user
        using (SqlCommand cmd2 = new SqlCommand())
        {
            cmd2.Connection = conn;
            cmd2.CommandText = @"INSERT INTO brugere (bruger_navn, Bruger_pass) VALUES (@bruger_navn, @bruger_pass)";
            cmd2.Parameters.AddWithValue("bruger_navn", txtUsername.Text);
            cmd2.Parameters.AddWithValue("bruger_pass", txtPassword.Text);
            cmd2.ExecuteNonQuery();
        }
    }
    conn.Close();
