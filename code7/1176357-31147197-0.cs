    string queryString = "product[description]=GreatStuff" +
            "&product[extra_info]=Extra";
    var queryStringCollection = HttpUtility.ParseQueryString(queryString);
    var cleanQueryStringDictionary = queryStringCollection.AllKeys
                                        .ToDictionary
                                        (
                                            key => key.Replace("product[", string.Empty).Replace("]", string.Empty),
                                            key => queryStringCollection[key]
                                        );
    var holder = new { product = cleanQueryStringDictionary };
    string jsonText = JsonConvert.SerializeObject(holder);
