    public static string GetServerBaseUrl(string FallbackValue = null)
        {
            try
            {
                string serverUrl = (string)GetContext().Invoke("getClientUrl");
                //Remove the trailing forwards slash returned by CRM Online
                //So that it is always consistent with CRM On Premises
                if (serverUrl.EndsWith("/"))
                {
                    serverUrl = serverUrl.Substring(0, serverUrl.Length - 1);
                }
                return serverUrl;
            }
            catch
            {
                //Try the old getServerUrl
                try
                {
                    string serverUrl = (string)GetContext().Invoke("getServerUrl");
                    //Remove the trailing forwards slash returned by CRM Online
                    //So that it is always consistent with CRM On Premises
                    if (serverUrl.EndsWith("/"))
                    {
                        serverUrl = serverUrl.Substring(0, serverUrl.Length - 1);
                    }
                    return serverUrl;
                }
                catch
                {
                       return FallbackValue;   
                }
            }
        }
