    public class AzureActiveDirectoryService : IAzureActiveDirectoryService
    {
        public string GetDatabaseAccessToken(AuthenticationContext authContext, ClientAssertionCertificate certCred)
        {
            try
            {
                return AcquireDatabaseToken(certCred, authContext);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occurred while attempting to retrieve database access token.");
            }
            return string.Empty;
        }
        private string AcquireDatabaseToken(ClientAssertionCertificate certCred, AuthenticationContext authContext)
        {
            try
            {
                DoHttpRequest();
                return string.Empty;
            }
            catch (Exception ex)
            {
                Log.Error(ex,
                          "An error occurred",
                          ex.ToString());
            }
        }
        private string DoHttpRequest()
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString("http://www.google.com");
            }
            return string.Empty;
        }
    }
