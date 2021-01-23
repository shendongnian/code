    /// <summary>
    /// Make post request to url with given paramaters
    /// </summary>
    /// <param name="url">URL to post data to http://server.com/method </param>
    /// <param name="data">{ Data: data }</param>
    /// <returns>string server response</returns>
    public string PostData(string url, string data)
    {
        // json request, hard coded right now but use "data" paramater to set this value.
        string jsonRequest = "{\"Data\": \"data\"}"; // the json request
     
        var request = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
     
        // this could be different for your server
        request.ContentType = "application/json"; 
         
        // i want to do post and not get
        request.Method = "POST"; 
     
        // used to check if async call is complete
        bool isRequestCallComplete = false;
     
        // store the response in this
        string responseString = string.Empty;
     
        request.BeginGetRequestStream(ar =>
        {
            var requestStream = request.EndGetRequestStream(ar);
            using (var sw = new System.IO.StreamWriter(requestStream))
            {
                // write the request data to the server
                sw.Write(jsonRequest);
     
                // force write of all content 
                sw.Flush();
            }
     
            request.BeginGetResponse(a =>
            {
                var response = request.EndGetResponse(a);
                var responseStream = response.GetResponseStream();
                using (var sr = new System.IO.StreamReader(responseStream))
                {
                    // read in the servers response right here.
                    responseString = sr.ReadToEnd();
                }
                // set this to true so the while loop at the end stops looping.
                isRequestCallComplete = true;
            }, null);
     
        }, null);
     
        // wait for request to complete before continuing
        // probably want to add some sort of time out to this 
        // so that the request is stopped after X seconds.
        while (isRequestCallComplete == false) { Thread.Sleep(50); }
     
        return responseString;
    }
