    <!-- language: c# -->
        SqlConnectionStringBuilder _ConnectionStringBuilder =
                                         new SqlConnectionStringBuilder();
        _ConnectionStringBuilder.DataSource = ServerName;
        _ConnectionStringBuilder.InitialCatalog = DBName;
        _ConnectionStringBuilder.UserID = Login;
        _ConnectionStringBuilder.Password = Password;
