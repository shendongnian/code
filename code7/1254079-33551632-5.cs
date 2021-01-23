    // Get these from the Stormpath admin console
    private static string API_KEY_ID = "Your_Stormpath_API_key_ID";
    private static string API_KEY_SECRET = "Your_Stormpath_API_key_secret";
    static void Main(string[] args)
    {
        // First, we need to get the current tenant's actual URL
        string tenantUrl = null;
        var getCurrentTenantRequest = BuildRequest("GET", "https://api.stormpath.com/v1/tenants/current");
        try
        {
            using (var response = getCurrentTenantRequest.GetResponse())
            {
                tenantUrl = response.Headers["Location"];
            }
        }
        catch (WebException wex)
        {
            Console.WriteLine("Request failed. {0}", wex.Message);
            throw;
        }
        // Now that we have the real tenant URL, get the tenant info
        string tenantData = null;
        var getTenantInfoRequest = BuildRequest("GET", tenantUrl);
        try
        {
            using (var response = getTenantInfoRequest.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                tenantData = reader.ReadToEnd();
            }
        }
        catch (WebException wex)
        {
            Console.WriteLine("Request failed. {0}", wex.Message);
            throw;
        }
        // Use JSON.NET to parse the data and get the tenant name
        var parsedData = JsonConvert.DeserializeObject<Dictionary<string, object>>(tenantData);
        Console.WriteLine("Current tenant is: {0}", parsedData["name"]);
        // Wait for user input
        Console.ReadKey(false);
    }
