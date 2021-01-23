    var connStringBuilder = new SqlConnectionStringBuilder();
    connStringBuilder.DataSource = ".\SQLEXPRESS";
    connStringBuilder.IntegratedSecurity = true;
    connStringBuilder.InitialCatalog = "LocalDB";
    
    SqlConnection conn = new SqlConnection(connStringBuilder)
