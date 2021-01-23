    try
    {
        string time = DateTime.Now.ToString("R", System.Globalization.CultureInfo.InvariantCulture);
        string tosign = "GET\n" +
                            "\n" +  //Content-Encoding
                            "\n" +  //Content-Language
                            "\n" +  //Content-Length
                            "\n" +  //Content-MD5
                            "\n" +  //Content-Type
                            "\n" +  //Date
                            "\n" +  //If-modified-since
                            "\n" +  //If-match
                            "\n" +  //If-none-match
                            "\n" +  //If-unmodified-since
                            "\n" +  //Range
                            "x-ms-date:" + time + "\nx-ms-version:2015-02-21\n" +   //CanonicalizedHeaders
                            "/storage_name/\ncomp:list";    //CanonicalizedResource
    
        string hashKey = "DHpNuYG5MXhamfbKmFPClUlNi38QiM2uqIqz07pgvpv2gmXJRwxaMlcV05pFCYsrelGYKPed9QphyJ/YnUrh5w=="; //Primary access key
    
        
       string hashedString = GetEncodedSignature(tosign, hashKey); //Shaun's answer method
        var client = new HttpClient();
        Uri uri = new Uri("https://storage_name.blob.core.windows.net/?comp=list");
        client.DefaultRequestHeaders.Add("x-ms-date", time);
        client.DefaultRequestHeaders.Add("x-ms-version", "2015-02-21");
        client.DefaultRequestHeaders.Add("Authorization", "SharedKey storage_name:" + hashedString);
        var response = await client.GetAsync(uri);
    }
    catch(Exception ex)
    {
        Debug.WriteLine(ex.ToString());
    }
