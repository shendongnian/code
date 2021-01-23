    public async Task<string> GetResult(){
        using(var httpClient = new HttpClient()){
            var httpResponse = await httpClient.GetAsync(requestMessage);
            return await httpResponse.Content.ReadAsStringAsync();
        }
    }
