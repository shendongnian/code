    async void btn_click(string username,string password)
    {
        // This should be an async method as well
        Client myClient = new Client();
        // added await
        string content = await myClient.authenticate(username, password);
        Console.Out.WriteLine(content);
    }
