    public class MyService : WebService
    {
        [WebMethod]
        public async Task<string> GetData() 
        {
             string response = await ExecuteRequest(externalUrl, someContent);
             return response;
        }
        private async Task<string> ExecuteRequest(string url, string content)
        {
             var httpResponse = await new HttpClient().PostAsync(url, new StringContent(content));
             string responseStr = await httpResponse.Content.ReadAsStringAsync();
             return responseStr;
        }
    }
