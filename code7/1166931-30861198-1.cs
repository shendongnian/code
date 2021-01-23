    using (var client = new HttpClient()) {
           var byteArray = Encoding.ASCII.GetBytes("my_client_id:my_client_secret");
           var header = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(byteArray));
           client.DefaultRequestHeaders.Authorization = header;
    
           return await client.GetStringAsync(uri);
    }
   
