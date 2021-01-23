    using (var con = new SqlConnection("...Conenction-String..."))
    {
        try
        {
            con.Open();
            // ...
        } catch (SqlException ex)
        {
            if (ex.Number == 927)
            {
                string database = con.Database;
                //show user friendly message
            }
        }
    }
