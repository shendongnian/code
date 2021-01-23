    SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
    b.DataSource = "190.xxx.xxx.xxx\ServerName";
    b.InitialCatalog = "DataBaseName";
    b.IntegratedSecurity = false;
    b.UserId = "...";
    b.Password = "...";
    string connectionString = b.ConnectionString;
