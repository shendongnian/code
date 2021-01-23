    private async void Foo()
    {
        // Succeeds, correct username and password.
        await Foo("foo", "bar");
        // Fails, wrong username and passord.
        await Foo("fizz", "buzz");
    }
    private async Task Foo(string user, string password)
    {
        Uri uri = new Uri("http://heyhttp.org/?basic=1&user=foo&password=bar");
        HttpClientHandler handler = new HttpClientHandler();
        handler.Credentials = new System.Net.NetworkCredential(user, password);
        HttpClient client = new HttpClient(handler);
        Debug.WriteLine(await client.GetAsync(uri));
    }
   
