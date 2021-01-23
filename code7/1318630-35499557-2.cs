    public async void Register{
            String data = "register=" + (accountName) + "&email0=" +
                (email) + "&email1=" + (otherEmail);
            var task = await MakeRequest(data);
            String resultstring = taskContent.ReadAsStringAsync().Result;
    }
    private static async Task<System.Net.Http.HttpResponseMessage> MakeRequest(String data)
    {
        var content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");
        var httpClient = new System.Net.Http.HttpClient();
        return await httpClient.PostAsync(server, content).ConfigureAwait(false);
    }
