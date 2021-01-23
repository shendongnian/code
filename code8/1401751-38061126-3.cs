            // LOG INTO FACEBOOK ACCT
            string email = "youremail@blah.com";
            string pw = "yourPassWord";
            CookieContainer cookieJar = new CookieContainer();
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create("https://www.facebook.com");
            request1.CookieContainer = cookieJar;
            request1.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
            //Get the response from the server and save the cookies from the first request..
            HttpWebResponse response = (HttpWebResponse)request1.GetResponse();
            var cookies = response.Cookies;
            cookieJar.Add(cookies);
            response.Close();// close the response
            string getUrl = "https://www.facebook.com/login.php?login_attempt=1";
            string postData = String.Format("email={0}&pass={1}", email, pw);
            HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(getUrl);
            getRequest.CookieContainer = cookieJar;
            //Adding Previously Received Cookies 
            getRequest.CookieContainer.Add(cookies);
            getRequest.Method = WebRequestMethods.Http.Post;
            getRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
            getRequest.AllowWriteStreamBuffering = true;
            getRequest.ProtocolVersion = HttpVersion.Version11;
            getRequest.AllowAutoRedirect = true;
            getRequest.ContentType = "application/x-www-form-urlencoded";
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            getRequest.ContentLength = byteArray.Length;
            Stream newStream = getRequest.GetRequestStream(); //open connection
            newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
            newStream.Close();
            HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
            using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
            {
                string sourceCode = sr.ReadToEnd();
            } 
