    private void GetWebPage()
    {
    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(this.AddressTextBox.Text);
    Request.Method = "GET";
    HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
    string Server = Response.Server;
    HttpStatusCode StatusCode = Response.StatusCode;
    if (StatusCode == HttpStatusCode.OK)
    {
    Stream ResponseStream = Response.GetResponseStream();
    StreamReader Reader = new StreamReader(ResponseStream);
    this.webBrowser1.DocumentText = Reader.ReadToEnd();
    }
    else
    {
    this.BadURI = this.BadURI + 1;
    }
    }
