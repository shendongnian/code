    var content   = new StreamContent (stream) ;
    var multipart = await content.ReadAsMultipartAsync () ;
    foreach (var part in multipart)
    {
        if (part.Headers.ContentType.MediaType == "application/json")
        {
            // deserialize via stream e.g. part.ReadAsStreamAsync () or via string
            // using part.ReadAsStringAsync () to avoid charset grief
        }
        else
        using (var file = File.Create (parser.Filename))
            await part.CopyToAsync (file) ;
    }
