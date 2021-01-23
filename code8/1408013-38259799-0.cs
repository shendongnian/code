    public static void CreateAlert(string api, string message, string description, string entity, string[] teams,
        string user, string[] tags)
    {
        // Serialize the data to JSON
        var postData = new
        {
            apiKey = api,
            message,
            teams
        };
        var json = JsonConvert.SerializeObject(postData);
        // Set up a client
        var client = new WebClient();
        client.Headers.Add("Content-Type", "application/json");
        try
        {
            var response = client.UploadString("https://api.opsgenie.com/v1/json/alert", json);
            Console.WriteLine("Success!");
            Console.WriteLine(response);
        }
        catch (WebException wex)
        {
            using (var stream = wex.Response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                // OpsGenie returns JSON responses for errors
                var deserializedResponse = JsonConvert.DeserializeObject<IDictionary<string, object>>(reader.ReadToEnd());
                Console.WriteLine(deserializedResponse["error"]);
            }
        }
    }
