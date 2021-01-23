    var value = "somestring";
    var url = "https://api.github.com/repos/org/repo1/contents/sample.json";
    
    using (var webClient = new System.Net.WebClient())
    {
        var topicTypeJson = webClient.DownloadString(url);
        JArray validTopicTypes = JArray.Parse(topicTypeJson);
        if (!validTopicTypes.Contains(value))
        {
            Logger.LogError($"Value not found");
         }
    }
