            public YourModel MakeRequest(string requestUrl)
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                        }
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        var responseObject = serializer.Deserialize<YourModel>(response);
                        return responseObject;
                    }
                }
                catch (Exception e)
                {
                    // catch exception and log it
                    return null;
                }
    
            }
