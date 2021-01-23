    public static async Task<MyClass> GetInformationAsync(string accountId)
    {
        var response = await Client.GetAsync(UriData + "/" + accountId).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return JsonConvert.DeserializeObject<MyClass>(responseContent);
    }
