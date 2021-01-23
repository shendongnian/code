    public static async Task<dynamic> getDataFromService(string queryString)
    {
        using (var client = new HttpClient())
        {
             var responseText = await client.GetStringAsync(queryString);
             dynamic data = JsonConvert.DeserializeObject(responseText);
             return data;
        }
    }
