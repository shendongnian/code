    static void Main(string[] args)
    {
        String appid = "DemoAppId01082013GAL";
        String appcode = "AJKnXv84fjrb0KIHawS0Tg";
        String waypoint0 = "geo!52.5,13.4";
        String waypoint1 = "geo!52.5,13.45";
        // Customize URL according to geo location parameters
        String url = string.Format(baseUrl, appid, appcode, waypoint0, waypoint1);
        // Syncronous Consumption
        var syncClient = new WebClient();
        var content = syncClient.DownloadString(url);
        // Using JSON.NET to deserialize object
         var responseDataSerialized = JsonConvert.DeserializeObject<RootObject>(content);
        // visual display of content
        Console.WriteLine(content);
        // Here's using DataContractSerializer
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RootObject));
        using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
        {
            // deserialize the JSON object using the JSONResponseData type.
            var responseData = (RootObject)serializer.ReadObject(ms);
            // Set breakpoint here to monitor responseData value
            Console.ReadLine();
        }
    }
