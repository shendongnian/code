    using (var con = new SqlConnection("...Conenction-String..."))
    {
        try
        {
            con.Open();
            // ...
        } catch (SqlException ex)
        {
            string database = con.Database;
            if (ex.Number == 927)
            {
                //show user friendly message
                string errorMessage = string.Format("Could not open database '{0}' since it's currently restoring. Please inform your database administrator."
                                                   , database);
                MessageBox.Show( errorMessage );
            }
        }
    }
