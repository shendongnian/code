    RallyRestApi restApi = new RallyRestApi(webServiceVersion: "v2.0");
    
    string user = Properties.Settings.Default.username;
    string pass = Properties.Settings.Default.password;
    string rallyURL = Properties.Settings.Default.rallyURL;
    
    restApi.Authenticate(user, pass, rallyURL, proxy: null, allowSSO: false);
