    public static class Main
    {
        string url = "https://TheDomainYouWantToContact.com/products/1";
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        var httpResponse = (HttpWebResponse)request.GetResponse();
    
        var dataStream = httpResponse.GetResponseStream();
        var reader = new StreamReader(dataStream);
        var responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
    
        // This is the code that turns the JSON string into the Product object.
        Product productFromServer = JsonConvert.Deserialize<Product>(responseFromServer);
        Console.Writeline(productFromServer.Id);
    }
    
    // This is the class that represents the JSON that you want to post to the service.
    public class Product
    {
        public string Id { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
