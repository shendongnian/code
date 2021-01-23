    /* ------------------------------------------------------------------------- */
    public Database(string source, string database, string user, string password,
        int timeout, DelegateConnectionResult connectResult)
    {
        this.timeout = timeout;
        this.connectResult = connectResult;
        connectString = "server=" + source +
              ";database=" + database +
              ";uid=" + user + 
              ";pwd=" + password + 
              ";connect timeout=" + Convert.ToInt16(timeout / 1000);
    }
