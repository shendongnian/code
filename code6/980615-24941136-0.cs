           try
           {
               _webResponse = (HttpWebResponse)_request.GetResponse();
               if(_request.HaveResponse)
               {
                   if (_webResponse.StatusCode == HttpStatusCode.OK)
                   {
                       var _stream = _webResponse.GetResponseStream();
                       using (var _streamReader = new StreamReader(_stream))
                       {
                           string str = _streamReader.ReadToEnd();
