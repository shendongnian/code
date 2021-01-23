    public Server(string serverName, string loginUsername, string loginPassword)
    {
        this.ServerName = serverName;
        this.LoginUsername = loginUsername;
        this.LoginPassword = loginPassword;
        // Login to server and retrieve list of services
        ConnectionTools = new ServerConnectionTools(this);
        this.Services = ConnectionTools.FetchServiceTools();
    }
