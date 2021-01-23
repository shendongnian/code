    var client = new HttpClient(new PublicContentHandler());
    client.BaseAddress = new Uri(_webApiAddress);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
    public class PublicContentHandler : HttpClientHandler
            {
                public PublicContentHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                }
            } 
