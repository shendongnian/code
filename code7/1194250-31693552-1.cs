    string _url = "http://37.130.202.188/class/sms/webservice/send_url.php?from=50005150149148&to=09120838238&msg=Hi&uname=*****&pass=****";
    string _respose = GetResponse(_url);
    public string GetResponse(string sURL)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL); request.MaximumAutomaticRedirections = 4;
        request.Credentials = CredentialCache.DefaultCredentials;
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); string sResponse = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
            return sResponse;
        }
        catch
        {
            lblMsg.Text = "There might be an Internet connection issue..";
            return "";
        }
    }
