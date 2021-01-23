    protected void Application_Start(object sender, EventArgs e)
    {
        Application["allSessions"] = new List<HttpSessionState>();
    }
    
    protected void Session_Start(object sender, EventArgs e)
    {
        var allSessions= (List<HttpSessionState>)Application["allSessions"];
        sessions.Add(this.Session);
    }
    
    protected void Session_End(object sender, EventArgs e)
    {
        var sessions = (List<HttpSessionState>)Application["allSessions"];
        sessions.Remove(this.Session);
    }
