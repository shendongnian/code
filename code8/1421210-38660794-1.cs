    using System;
    using System.Net;
    
    //create a request object and server call
    Uri requestUri = new Uri("MyPhp Uri");
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.requestUri);
    //set all properties you need for the request, like
    request.Method = "GET";
    request.BeginGetResponse(new AsyncCallback(ProcessResponse), request);
    
    
    //handle response
    private void ProcessResponse(IAsyncResult asynchronousResult)
    {
        string responseData = string.Empty;
        HttpWebRequest myrequest = (HttpWebRequest)asynchronousResult.AsyncState;
        using (HttpWebResponse response = (HttpWebResponse)myrequest.EndGetResponse(asynchronousResult))
        {
            Stream responseStream = response.GetResponseStream();
            using (var reader = new StreamReader(responseStream))
            {
                responseData = reader.ReadToEnd();
            }
            responseStream.Close();
        }
        //TODO: do something with your responseData 
    }
    
