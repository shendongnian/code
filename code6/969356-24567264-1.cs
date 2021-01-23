    public async Task<String> GetGoogle()
    {
        var result = await new WebClient().DownoadString("http://www.google.com");
        return result;
    }
    public void Main()
    {
        Console.WriteLine(GetGoogle().Result);
    }
