    public async Task<String> GetGoogle()
    {
        await var result = new WebClient().DownoadString("http://www.google.com");
        return result;
    }
    public void Main()
    {
        Console.WriteLine(GetGoogle().Result);
    }
