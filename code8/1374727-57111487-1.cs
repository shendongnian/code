    public static string GetConnectionString(string name)
    {
        string conStr = System.Environment.GetEnvironmentVariable($"ConnectionStrings:{name}", 
                        EnvironmentVariableTarget.Process);
        // Azure Functions App Service naming 
        if (string.IsNullOrEmpty(conStr))convention
            conStr = System.Environment.GetEnvironmentVariable($"SQLAZURECONNSTR_{name}", 
                     EnvironmentVariableTarget.Process);
        return conStr;
    }
