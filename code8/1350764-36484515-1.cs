    try
    {
        try
        {
            var dataset = JsonConvert.DeserializeObject<DataSet>(response.Content);
            var results = dataset.Tables["result"];
            return results;
        }
        catch (JsonException)
        {
            var token = JToken.Parse(response.Content);
            if (token.Type == JTokenType.Object && ((JToken)"failure").Equals(token["status"]))
            {
                // Handle error explicitly
                return null;
            }
            // OK, it's not an explicit error. rethrow
            throw;
        }
    }
    catch (Exception ex)
    {
        // Generic error in the code somewhere.
        Debug.WriteLine(ex);
        // ... Other error handling as required
    }
