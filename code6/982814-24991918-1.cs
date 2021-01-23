        try
        {
           // Code
        }
        catch(SqlException ex)
        {
            if (ex.Number == 2627)
            {
                 MessageBox.Show("An error", "The same value already exists - change some data", MessageBoxIcon.Error, MessageBoxButton.OK);
            }
        }
    
