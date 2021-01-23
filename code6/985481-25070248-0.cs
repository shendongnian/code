    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        ApplicationSettings applicationSettings = new ApplicationSettings();
        applicationSettings.ServerIp = tbServer.Text;
        applicationSettings.MakeConnectionString();
       try
        {
             MySqlConnection connection = new MySqlConnection(applicationSettings.ConnectionString);
            connection.Open();
            MessageBox.Show(this, "server found", "OK !", MessageBoxButton.OK, MessageBoxImage.Information);
            connection.Close();
            applicationSettings.ServerDatabase = tbdbName.Text;
                try{
                    applicationSettings.MakeConnectionString();
                    connection = new MySqlConnection(applicationSettings.ConnectionString);
                    connection.Open();
                    MessageBox.Show(this, "Database found", "OK !", MessageBoxButton.OK, MessageBoxImage.Information);
                    connection.Close();
                    applicationSettings.ServerUserName = tbUsername.Text;
                    applicationSettings.ServerPassword = pbPassword.SecurePassword;
                            try{
                                applicationSettings.MakeConnectionString();
                                connection = new MySqlConnection(applicationSettings.ConnectionString);
                                connection.Open();
                                MessageBox.Show(this, "Server,database and account are valid", "OK !", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            catch(Exception ee){
                                               MessageBox.Show(this, "Error: Account  parameters not valid!! " + ee.Message, "connection ERROOOOR", MessageBoxButton.OK,
                                               MessageBoxImage.Error);
                                               }
                               }
                 catch(Exception ee){
                                MessageBox.Show(this, "Error: server is connected but the database not found!! " + ee.Message, "connection ERROOOOR", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                                     }
        }
        catch (Exception ee)
        {
            MessageBox.Show(this, "Error: server not found " + ee.Message, "connection ERROOOOR", MessageBoxButton.OK,
                MessageBoxImage.Error);
    
        }
        finally
        {
            if(connection.State == ConnectionState.Open)
                connection.Close();
        }
    
    }
