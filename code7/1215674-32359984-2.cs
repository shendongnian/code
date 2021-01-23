    // your "main" method
    private void Parse(string json) // <- pass in your JSON as string
    {
        string properties = string.Empty;
        // parse JSON onbject
        JObject jsonObject = JObject.Parse(json);
        // get an array, which is token called "data"
        JArray data = jsonObject.SelectToken("data").Value<JArray>();
        // iterate over all tokens in data array (in this case just one)
        foreach (JToken token in data.Children())
        {
            // get names and values of all properties within current token 
            foreach (JProperty property in token.Children<JProperty>())
                properties += GetProperty(property);
        }
        // print out results
        Console.WriteLine(properties);
    }
