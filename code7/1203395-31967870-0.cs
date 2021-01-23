    using System.Web;
    using System.Collections.Specialized;
    using System.Deployment.Application;
    ...
    private NameValueCollection GetQueryStringParameters()
    {
        NameValueCollection nameValueTable = new NameValueCollection();
        if (ApplicationDeployment.IsNetworkDeployed)
        {
            string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
            nameValueTable = HttpUtility.ParseQueryString(queryString);
        }
        return (nameValueTable);
    }
