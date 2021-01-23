    private void Login() // login method
    {
        string connectString = "datasource=IPorDomainNameofserver;
                              port=AddThisIfneeded;
                              Database=DataBaseName;
                              username=UserID/Name;
                              password=Password;";
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
