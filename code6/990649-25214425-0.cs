    public void GetWebAddress(string web_address)
    {
        HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(web_address);
        if (request != null) request.BeginGetResponse(MyHttpCallback, request);            
    }
    void MyHttpCallback(IAsyncResult result)
    {
        HttpWebRequest request = result.AsyncState as HttpWebRequest;
        if (request != null)
        {
            try
            {
                // if you're using 8.1 try enclosing theses lines with "using"
                // there is no .Close()
                WebResponse response = request.EndGetResponse(result);
                StreamReader reader;
                reader = new StreamReader(response.GetResponseStream());
                string responseText = reader.ReadToEnd();
                // reponseText now contains the html/text of the page
                reader.Close();
                response.Close();
            }
            catch (WebException e)
            {
                // your errors are here, set your flags
                string error_string = e.Message;
            }
        }
    }
