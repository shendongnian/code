    public EnumProduct Post(EnumProduct product)
    {
    HttpResponseMessage reponse = httpClient.PostAsJsonAsync("api/enumproducts/Post", product).Result;
    if (reponse.IsSuccessStatusCode)
    {
    var enumProduct = reponse.Content.ReadAsAsync().Result;
    return enumProduct;
    }
    else
    return null;
    }
