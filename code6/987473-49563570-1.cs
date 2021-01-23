    public class ReuseRemoteWebDriver : OpenQA.Selenium.Remote.RemoteWebDriver
    {
        private String _sessionId;
    public ReuseRemoteWebDriver(Uri remoteAddress, String sessionId)
        : base(remoteAddress, new OpenQA.Selenium.Remote.DesiredCapabilities())
    {
        this._sessionId = sessionId;
        var sessionIdBase = this.GetType()
            .BaseType
            .GetField("sessionId",
                      System.Reflection.BindingFlags.Instance |
                      System.Reflection.BindingFlags.NonPublic);
        sessionIdBase.SetValue(this, new OpenQA.Selenium.Remote.SessionId(sessionId));
    }
    protected override OpenQA.Selenium.Remote.Response
        Execute(string driverCommandToExecute, System.Collections.Generic.Dictionary<string, object> parameters)
    {
        if (driverCommandToExecute == OpenQA.Selenium.Remote.DriverCommand.NewSession)
        {
            var resp = new OpenQA.Selenium.Remote.Response();
            resp.Status = OpenQA.Selenium.WebDriverResult.Success;
            resp.SessionId = this._sessionId;
            resp.Value = new System.Collections.Generic.Dictionary<String, Object>();
            return resp;
        }
        var respBase = base.Execute(driverCommandToExecute, parameters);
        return respBase;
    }
}
