    string connStr = "Data Source=servername;User ID=user1;Password=380kj";
    System.Data.SqlClient.SqlConnectionStringBuilder sb = new System.Data.SqlClient.SqlConnectionStringBuilder(connStr);
    sb.UserID = "XXXXX";
    sb.Password = "XXXXX";
    connStr = sb.ToString();
