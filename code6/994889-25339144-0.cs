    // Define your SQL query - WITH parameters! 
    // And always specify the list of columns for your INSERT!
    string query = "INSERT INTO dbo.Table1(CurrentTime) VALUES(@TimeValue)";
    // use the "using" blocks to properly protect your disposable connection and command
    using (SqlConnection con = new SqlConnection("server=.;database=test;integrated security=SSPI;"))
    using (SqlCommand cmd = new SqlCommand(query, con))
    {
        string hr = txtHr.Text; 
        string min = txtMin.Text; 
        string time = hr + ":" + min;
        // set the parameter value
        cmd.Parameters.Add("@TimeValue", SqlDbType.Time).Value = TimeSpan.Parse(time);
        // open connection, execute your INSERT, close connection
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
