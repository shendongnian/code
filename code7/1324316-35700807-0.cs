    public static async HttpResponseMessage PostBson<T>(string url, T data)
    {    
                using (var client = new HttpClient())
                {
                    //Specifiy 'Accept' header As BSON: to ask server to return data as BSON format
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/bson"));                    
    
                    //Specify 'Content-Type' header: to tell server which format of the data will be posted
                    //Post data will be as Bson format                
                    var bSonData = HttpExtensions.SerializeBson<T>(data);
                    var byteArrayContent = new ByteArrayContent(bSonData);
                    byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/bson");
    
                    var response = await client.PostAsync(url, byteArrayContent);
    
                    response.EnsureSuccessStatusCode();
    
                    return response;
                }           
    }
