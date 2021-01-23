    public async Task<HttpResponseMessage> SendPost(JObject data)
    {
        RentalApplication application = data["application"].ToObject<RentalApplication>();
        string test = data["test"].ToObject<string>();
    }
