    using (OdbcDataReader reader = command.ExecuteReader())
    {
    
        if (reader.HasRows)
        {
            Response.Write("Welcome!");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('no data.');", true);
        }
    }
