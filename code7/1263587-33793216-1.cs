    private string m_serverName;
    private string m_loginUsername;
    private string m_loginPassword;
    private ServerConnectionTools m_connectionTools;
    public List<Service> Services { get; private set; }
    public Server(string serverName, string loginUsername, string loginPassword)
    {
        this.ServerName = serverName;
        this.LoginUsername = loginUsername;
        this.LoginPassword = loginPassword;
        // Login to server and retrieve list of services
        ConnectionTools = new ServerConnectionTools(this);
    }
    public void setList(List<StringBuilder> par_list)
    {
          //do whatever you need to here.
    }
