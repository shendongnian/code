    private async Task<string> CallApi(SurveyData sd)
    {
        string result = String.Empty;
        using (var client = new HttpClient())
        {
        
            string url = ConfigurationManager.AppSettings["url"];
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.PostAsJsonAsync(url, sd);
 
            if (response.IsSuccessStatusCode)
            {
                result = "Success";
            }
            else
            {
                result = response.StatusCode + " : Message - " + response.ReasonPhrase;
            }
        }
        return result;
    }
