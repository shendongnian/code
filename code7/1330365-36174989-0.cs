    class MantisWebRequest
    {
        public string Password { private get; set; }
        public string Username { private get; set; }
        public CookieContainer CookieContainer { get; private set; }
        public StreamReader Reader { get; private set; }
        public Stream DataStream { get; private set; }
        public WebResponse Response { get; private set; }
        public HttpWebRequest Request { get; private set; }
        public string Page { get; private set; }
        public MantisWebRequest(string username, string password)
        {
            Username = username;
            Password = password;
            CookieContainer = new CookieContainer();
        }
        public void Connect(string cookieName = null)
        {
            string loginurl = "http://mantispageurl/login.php";
            // Create a request using a URL that can receive a post. 
            Request = (HttpWebRequest)System.Net.WebRequest.Create(loginurl);
            // Set the Method property of the request to POST.
            Request.Method = "POST";
            Request.KeepAlive = true;
            if (cookieName != null)
                CookieContainer.Add(new Cookie(cookieName, Username, "/", new Uri(loginurl).Host));
            Request.CookieContainer = CookieContainer;
            // Create POST data and convert it to a byte array.  Modify this line accordingly
            string postData = String.Format("username={0}&password={1}&secure_session=on", Username, Password);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            Request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            Request.ContentLength = byteArray.Length;
            // Get the request stream.
            DataStream = Request.GetRequestStream();
            // Write the data to the request stream.
            DataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            DataStream.Close();
            // Get the response.
            Response = Request.GetResponse();
            // Get the stream containing content returned by the server.
            DataStream = Response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            Reader = new StreamReader(DataStream);
            // Read the content.
            Page = Reader.ReadToEnd();
            // Clean up the streams.
            Reader.Close();
            DataStream.Close();
            Response.Close();
        }
        private void POST(string url, string postData)
        {
            Request = (HttpWebRequest)System.Net.WebRequest.Create(url);
            Request.Method = "POST";
            Request.KeepAlive = true;
            Request.CookieContainer = CookieContainer;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            Request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            Request.ContentLength = byteArray.Length;
            // Get the request stream.
            DataStream = Request.GetRequestStream();
            // Write the data to the request stream.
            DataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            DataStream.Close();
            Response = Request.GetResponse();
            // Get the stream containing content returned by the server.
            DataStream = Response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            Reader = new StreamReader(DataStream);
            // Read the content.
            Page = Reader.ReadToEnd();
            // Clean up the streams.
            Reader.Close();
            DataStream.Close();
            Response.Close();
        }
        private void POST(string url, string postData, string tokenName)
        {
            string token = GetToken(tokenName);
            Request = (HttpWebRequest)System.Net.WebRequest.Create(url);
            Request.Method = "POST";
            Request.KeepAlive = true;
            Request.CookieContainer = CookieContainer;
            postData = string.Format("{0}={1}&{2}", tokenName, token, postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            Request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            Request.ContentLength = byteArray.Length;
            // Get the request stream.
            DataStream = Request.GetRequestStream();
            // Write the data to the request stream.
            DataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            DataStream.Close();
            Response = Request.GetResponse();
            // Get the stream containing content returned by the server.
            DataStream = Response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            Reader = new StreamReader(DataStream);
            // Read the content.
            Page = Reader.ReadToEnd();
            // Clean up the streams.
            Reader.Close();
            DataStream.Close();
            Response.Close();
        }
        private void GET(string url)
        {
            Request = (HttpWebRequest)System.Net.WebRequest.Create(url);
            Request.Method = "GET";
            Request.CookieContainer = CookieContainer;
            Response = Request.GetResponse();
            // Get the stream containing content returned by the server.
            DataStream = Response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            Reader = new StreamReader(DataStream);
            // Read the content.
            Page = Reader.ReadToEnd();
            // Clean up the streams.
            Reader.Close();
            DataStream.Close();
            Response.Close();
        }
        private string GetToken(string tokenName)
        {
            int tokenIndex = Page.IndexOf(tokenName);
            int endindex = tokenIndex + Page.Substring(tokenIndex).IndexOf(">", StringComparison.Ordinal);
            int startindex = Page.Substring(0, tokenIndex).LastIndexOf("<", StringComparison.Ordinal);
            string input = Page.Substring(startindex, endindex - startindex + 1);
            string valuestring = "value=\"";
            int tokenIndex2 = input.IndexOf(valuestring, StringComparison.Ordinal);
            int endindex2 = tokenIndex2 + valuestring.Length + input.Substring(tokenIndex2 + valuestring.Length).IndexOf("\"", StringComparison.Ordinal);
            int startindex2 = tokenIndex2 + valuestring.Length;
            string output = input.Substring(startindex2, endindex2 - startindex2);
            return output;
        }
        public void UpdateStatus(int[] issueIds, int statusId)
        {
            string tokenName = "bug_actiongroup_UP_STATUS_token";
            string formUrl = GetUpdateStatusUrl(issueIds);
            string formPostDataUrl = "http://mantispageurl/bug_actiongroup.php";
            string formPostData = GetUpdateStatusPostData(issueIds, statusId);
            GET(formUrl);
            POST(formPostDataUrl, formPostData, tokenName);
        }
        private string GetUpdateStatusUrl(int[] issueIds)
        {
            string postData = "?";
            foreach (var issueId in issueIds)
            {
                postData = string.Format("{0}&bug_arr%5B%5D={1}", postData, issueId);
            }
            postData = String.Format("{0}&action=UP_STATUS", postData);
            return "http://mantispageurl/bug_actiongroup_page.php" + postData;
        }
        private string GetUpdateStatusPostData(int[] issueIds, int statusId)
        {
            string postData = "action=UP_STATUS";
            foreach (var issueId in issueIds)
            {
                postData = string.Format("{0}&bug_arr%5B%5D={1}", postData, issueId);
            }
            postData = String.Format("{0}&status={1}&bugnote_text=", postData, statusId);
            return postData;
        }
