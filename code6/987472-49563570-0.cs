    var sessionIdProperty = typeof(RemoteWebDriver).GetProperty("sessionId", BindingFlags.Instance | BindingFlags.NonPublic); //sessionId
                if (sessionIdProperty != null)
                {
                    SessionId sessionId = sessionIdProperty.GetValue(driver, null) as SessionId;
                    sId = sessionId.ToString();//((RemoteWebDriver)driver).Capabilities.GetCapability("webdriver.remote.sessionid").ToString();
    
                }
