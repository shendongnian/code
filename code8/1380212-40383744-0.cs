        private static string GetConnectionString(string model, string providerConnectionString)
    {
      var efConnection = new EntityConnectionStringBuilder();
      // or the config file based connection without provider connection string
      // var efConnection = new EntityConnectionStringBuilder(@"metadata=res://*/model1.csdl|res://*/model1.ssdl|res://*/model1.msl;provider=System.Data.SqlClient;");
      efConnection.Provider = "System.Data.SqlClient";
      efConnection.ProviderConnectionString = providerConnectionString;
      // based on whether you choose to supply the app.config connection string to the constructor
      efConnection.Metadata = string.Format("res://*/correctModel.{0}.csdl|res://*/correctModel.{0}.ssdl|res://*/correctModel.{0}.msl", model);
      // Make sure the "res://*/..." matches what's already in your config file.
      return efConnection.ToString();
    }
