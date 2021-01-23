    private void Login() // login method
    {
        string connectString = @"uid=<UserID>;password=<Password>;
                               server=<IPorDomainNameOfDatabase>;
                               database=<DatabaseNameOnServer>;";;
        using(MySqlConnection cnn = new MySqlConnection(connectString))
        {
            try
            {
                cnn.Open();
            }
            catch (Exception e)
            {
               .....
            }
        }
    }
