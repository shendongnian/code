    // Creating and disposing HttpClient is unnecessary
    // if you are going to use it multiple time
    // reusing HttpClient improves performance !!
    // do not worry about memory leak, HttpClient
    // is designed to close resources used in single "SendAsync"
    // method call
    private static HttpClient client;
    public Task<T> DownloadAs<T>(string url){
        // I know I am firing this on another thread
        // to keep UI free from any smallest task like
        // preparing httpclient, setting headers
        // checking for result or anything..., why do that on
        // UI Thread?
        // this helps us using excessive logging required for
        // debugging and diagnostics
        return Task.Run(async ()=> {
           // following parses url and makes sure
           // it is a valid url
           // there is no need for this to be done on 
           // UI thread
           Uri uri = new Uri(url);
           HttpRequestMessage request = 
              new HttpRequestMessage(uri,HttpMethod.Get);
           // do some checks, set some headers...
           // secrete code !!!
           var response = await client.SendAsync(request,
               HttpCompletionOption.ReadHeaders);
           
           string content = await response.Content.ReadAsStringAsync();
           if(((int)response.StatusCode)>300){
               // it is good to receive error text details
               // not just reason phrase
                
               throw new InvalidOperationException(response.ReasonPhrase  
                  + "\r\n" + content);
           }
           return JsonConvert.DeserializeObject<T>(content);
        });
    }
