    SqlCommand.ExecuteNonQuery(asd)
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0; AttachDbFilename=" + Application.StartupPath + "\\GlennTeoDB.mdf; Integrated Security=True;Connect Timeout=30");
    con.Open();
    int rowsAffected = cmd.ExecuteNonQuery();
    con.Close();
    if (!(rowsAffected > 0))
    {
        throw new ArgumentException(<Your Message>);
    }
    
