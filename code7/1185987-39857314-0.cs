           private void ExtractResponseData(HttpResponse response, HttpWebResponse webResponse)
            {
                using (webResponse)
                {
    #if FRAMEWORK
                    response.ContentEncoding = webResponse.ContentEncoding;
                    response.Server = webResponse.Server;
                    response.ProtocolVersion = webResponse.ProtocolVersion;
    #endif
                    response.ContentType = webResponse.ContentType;
                    response.ContentLength = webResponse.ContentLength;
    
                    Stream webResponseStream = webResponse.GetResponseStream();
    
    #if WINDOWS_PHONE
                    if (string.Equals(webResponse.Headers[HttpRequestHeader.ContentEncoding], "gzip", StringComparison.OrdinalIgnoreCase))
                    {
                        GZipStream gzStream = new GZipStream(webResponseStream);
    
                        ProcessResponseStream(gzStream, response);
                    }
                    else
                    {
                        ProcessResponseStream(webResponseStream, response);
                    }
    #else
                    this.ProcessResponseStream(webResponseStream, response);
    #endif
    
                    response.StatusCode = webResponse.StatusCode;
                    response.StatusDescription = webResponse.StatusDescription;
                    response.ResponseUri = webResponse.ResponseUri;
                    response.ResponseStatus = ResponseStatus.Completed;
