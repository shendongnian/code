    var webRequest = WebRequest.Create(_baseUri + "/" + method);
    webRequest.Method = "POST";
    webRequest.ContentType = "application/json";
    webRequest.BeginGetRequestStream(OnRequested, webRequest);
    private void OnRequested(IAsyncResult ar)
    {
        var request = ar.AsyncState as WebRequest;
        if (request != null)
        {
            if (_data != null)
            {
                var dataStream = Encoding.UTF8.GetBytes(Serialize(_data));
                var requestStream = request.EndGetRequestStream(ar);
                requestStream.Write(dataStream, 0, dataStream.Length);
            }
            request.BeginGetResponse(OnResponse, request);
        }
    }
    private void OnResponse(IAsyncResult ar)
    {
        var request = ar.AsyncState as WebRequest;
        if (request != null)
        {
            _response = request.EndGetResponse(ar);
            var json = (new StreamReader(_response.GetResponseStream())).ReadToEnd();
        }
    }
