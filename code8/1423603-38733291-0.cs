    try
    {
        SqlConnection con = new SqlConnection(ConnectionString);
        con.Open();
        int count = 1;
        string key = string.Empty;
        
        while (count > 0)
        {
            key = RandomString(6);
            SqlCommand selectCommand = new SqlCommand("SELECT COUNT(*) FROM tableName WHERE d1 = @0", con);
            selectCommand.Parameters.Add(new SqlParameter("0", key));
            count = (int)selectCommand.ExecuteScalar();
        }
    
        SqlCommand insertCommand = new SqlCommand("INSERT INTO tableName(d1, d2, d3) VALUES (@0, @1, @2)", con);
    
        insertCommand.Parameters.Add(new SqlParameter("0", key));
        insertCommand.Parameters.Add(new SqlParameter("1", "values"));
        insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));
        var rowCount = insertCommand.ExecuteNonQuery();
    
    
        con.Close();
        if (rowCount < 1)
        {
            label.Text = "OMG it is Fail :(";
            return false;
        }
        else
        {
            label.Text = "HEY ~~~ inserted";
            return true;
        }
    }
    catch (Exception ex)
    {
        label.Text = ex.Message;
        return false;
    }
