    public static class Main
    {
        RestClient client = new RestClient();
        string url = "https://YourDomain.com/products/1";
        var productFromServer = client.Get<Product>(url);
        Console.Writeline(productFromServer.Id);
    }
