    public async Task SendDataAsync(Email email){
        using (var client = new HttpClient())
        {
            return client.PostAsync(email);
        }
    }
