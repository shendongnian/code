     public static async Task<string> GetData()
            {
        var result = true;
        var url = "API Call URL";
        var content = new Dictionary<string, string>();
        content["needed parameter for API call"] = ID;
        var response = await WebRequestHelper.MakeAsyncRequest(url, content);
                    if (response.IsSuccessStatusCode)
                    {
        result = response.Content.ReadAsStringAsync().Result;
        result = result.Replace("<xml>", "<ModelResultName>").Replace("</xml>", "</ModelResultName>");
                    }
                    else
                    {
                        result = false;
                        Debug.WriteLine("Failed to get data");
                    }
    return result;
