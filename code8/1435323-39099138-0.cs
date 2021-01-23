    private NameValueCollection GetQueryString()
    {
        if (ApplicationDeployment.IsNetworkDeployed)
        {
            try
            {
                string rawQueryString = String.Empty;
                rawQueryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                NameValueCollection queryString;
                try
                {
                    queryString = HttpUtility.ParseQueryString(ApplicationDeployment.CurrentDeployment.ActivationUri.Query);
                }
                catch (Exception ex)
                {
                    throw new Exception("Unauthorized access!");
                }
                return queryString;
            }
            catch (Exception ex)
            {
                if (ApplicationDeployment.CurrentDeployment == null)
                {
                    throw new Exception("Deployment error");
                }
                else if (ApplicationDeployment.CurrentDeployment.ActivationUri == null)
                {
                    throw new Exception("Unable to read data");
                }
                else
                {
                    throw new Exception("Error with deployment: " + ex.Message);
                }
            }
        }
        else
        {
            throw new Exception("This application may not be accessed directly");
        }
    }
