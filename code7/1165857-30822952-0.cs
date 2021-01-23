     private string _connectionString =
            @"Data Source =(LocalDB)\v11.0;AttachDBFileName=D:\Sample.mdf;" +
            "Integrated Security=true";
        private bool IsDbConnectionOk(out string errorMessage)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    if (connection.State != ConnectionState.Open)
                    {
                        errorMessage = null;
                        return false;
                    }
                    errorMessage = null;
                    return true;
                }
                catch (Exception exp)
                {
                    errorMessage = exp.Message;
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void BtnTestConnection_OnClick(object sender, RoutedEventArgs e)
        {
            string errormessage;
            var isOk = IsDbConnectionOk(out errormessage);
            if (isOk)
            {
                MessageBox.Show("Connection Is OK");
            }
            else
            {
                MessageBox.Show("Connection error : " + errormessage);
            }
        }
