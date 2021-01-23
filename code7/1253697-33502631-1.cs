    using (CustomWebClient client = new CustomWebClient())
    {   
         client.Headers.Add("HeaderName","Value");
         client.Post();
    }
