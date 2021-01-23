    public async void GetData()
    {
        ParseClient.Initialize("app_key", ".net_key");
        var query1 = ParseObject.GetQuery("test").WhereEqualTo("objectId", "xxxxxxxx");
        var result = await query1.FindAsync();
    }
