    public static string[] UserDetailsWebService(string username, string password)
    {
        string[] array = null;
    
        using (WebServiceUser.Users use = new WebServiceUser.Users())
        {
            try
            {
                WebServiceUser.UserGridList Grid = use.GetUserDetails(username, password, username);
    
                array = new string[] { Grid.FirstName, Grid.LastName };
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is HttpResponseException
                    || ex is WebException || ex is System.Net.Sockets.SocketException)
                {
                    //throws etc... 
                }
                else
                {
                    //throws etc... 
                }
            }
        }
    
        return array;
    }
