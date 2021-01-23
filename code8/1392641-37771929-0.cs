    public App()
    {
        CallApi();
    }
    private async void CallApi()
    {
        response = await GetFromAPI();
    }
