    public static string BuildEntityConnectionString(string connectionString, 
      Type contextType)
    {
        string result = string.Empty;
        string prefix = contextType.Namespace
          .Replace(contextType.Assembly.GetName().Name, 
          "");
        if (prefix.Length > 0
            && prefix.StartsWith("."))
        {
            prefix = prefix.Substring(1, prefix.Length - 1);
        }
        if (prefix.Length > 1
            && !prefix.EndsWith("."))
        {
            prefix += ".";
        }
        EntityConnectionStringBuilder csBuilder = 
          new EntityConnectionStringBuilder();
        csBuilder.Provider = "System.Data.SqlClient";
        csBuilder.ProviderConnectionString = connectionString;
        csBuilder.Metadata = string.Format("res://{0}/{1}.csdl|"
                                            + "res://{0}/{1}.ssdl|"
                                            + "res://{0}/{1}.msl"
                                            , ContextType.Assembly.FullName
                                            , prefix + ContextType.Name);
        result =  csBuilder.ToString();
        return result;
    }
