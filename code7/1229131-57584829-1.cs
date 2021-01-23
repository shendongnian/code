    public async Task<HttpResponseMessage> SendPost(RentalApplication application, string test)
    {
        RentalApplication application = data["application"].ToObject<RentalApplication>();
        string test = data["test"].ToObject<string>();
    }
