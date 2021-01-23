    var lines = File.ReadAllLines(productsFile, Encoding.GetEncoding(1252)).ToList();
    var products = lines
        .Select(p => p.Split(';'))
        .Select(p => new Product
        {
            ProductNumber = p[1],
            Name = p[2],
            Unit = p[3],
        }).ToList();
    
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["URL"].TrimEnd('/'));
        var result = client.PostAsJsonAsync("/api/products", products).Result;
        switch (result.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
                Trace.TraceError("Error in security token");
                break;
            case HttpStatusCode.InternalServerError:
                Trace.TraceError(result.ReasonPhrase + Environment.NewLine + result.Content.ReadAsStringAsync().Result.Replace("<br/>", Environment.NewLine));
                break;
            case HttpStatusCode.OK:
                Trace.TraceInformation("Updated " + products.Count() + " products ok");
                break;
            default:
                Trace.TraceError("Something else went wrong");
                break;
        }
    
    }
