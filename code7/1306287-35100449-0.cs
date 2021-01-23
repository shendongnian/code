    string siteContent = string.Empty;
    string url = "http://www.RESTFEEDURL.com";
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    using(Stream responseStream = response.GetResponseStream())
    using(StreamReader streamReader = new StreamReader(responseStream))
    {
        siteContent = streamReader.ReadToEnd();
    }
    //NOW PARSE THE DATA AND SEND TO DATABASE HERE
    //data is in siteContent
