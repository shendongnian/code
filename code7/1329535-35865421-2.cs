    public static SqlConnection GetConnection()
    {
        // if Windows Authentication is used, just get rid of user id and password and use Trusted_Connection=True; OR Integrated Security=SSPI; OR Integrated Security=true;
        String connStr = "Data Source=ServerName;Initial Catalog=DataBaseName;User id=UserName;Password=Secret;";
        return new SqlConnection(connStr);
    
    }
