     //if it is a root application, then the path will be "/"
     var configPath = "/YourApplicationName";
     var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath);
     // get the object related to the <sessionSate> section.
     var sessionSection = (System.Web.Configuration.SessionStateSection)config.GetSection("system.web/sessionState");
     // get the session timeout value
     var timeOut= SessionSection.Timeout;
