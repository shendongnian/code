    try
    {
       conString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
    }
    catch(Exception)
    {
       MessageBox.Show("Unable to retrieve 'ConnectionString' from configuration file.");
    }
