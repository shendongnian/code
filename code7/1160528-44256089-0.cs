    public ConnectionInfo GetCertificateBasedConnection()
        {
            ConnectionInfo connection;
            Debug.WriteLine("Trying to create certification based connection...");
            using (var stream = new FileStream(ConfigurationHelper.PrivateKeyFilePath, FileMode.Open, FileAccess.Read))
            {
                var file = new PrivateKeyFile(stream);
                var authMethod = new PrivateKeyAuthenticationMethod(ConfigurationHelper.User, file);
                connection = new ConnectionInfo(ConfigurationHelper.HostName, ConfigurationHelper.Port, ConfigurationHelper.User, authMethod);
            }
            Debug.WriteLine("Certification based connection created successfully");
            return connection;
        }
