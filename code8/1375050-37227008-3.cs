    try
    {
       conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    }
    catch(Exception)
    {
       MessageBox.Show("Unable to retrieve 'ConnectionString' from configuration file.");
    }
