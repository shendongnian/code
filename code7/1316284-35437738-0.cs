        public void LoginAlm(string StrServer, string StrUser, string StrPassword, string StrDomain, string StrProject)
        {
            //Creating the WebRequest with the URL and encoded authentication
            string StrServerLogin = StrServer + "/api/authentication/sign-in";
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(StrServerLogin);
            myWebRequest.Headers[HttpRequestHeader.Authorization] = "Basic " + Base64Encode(StrUser + ":" + StrPassword);
            WebResponse webResponse = myWebRequest.GetResponse();
            //Once this is done, we create a new request, this example to get the information about defect #1 on a given project
            HttpWebRequest myWebRequest1 = (HttpWebRequest)WebRequest.Create(StrServer + "/rest/domains/"+StrDomain+"/projects/"+StrProject+"/defects/1");
            
            //Then, we create a cookie container to the webrequest where we will store the cookie that we've received from the authentication webresponse
            myWebRequest1.CookieContainer = new CookieContainer();
            Uri target = new Uri(StrServer);
            //We extract the LWSSO_COOKIE_KEY cookie and add it to the cookie container
            string StrCookie = webResponse.Headers.ToString();
            string StrCookie1 = StrCookie.Substring(StrCookie.IndexOf("LWSSO_COOKIE_KEY=") + 17);
            StrCookie1 = StrCookie1.Substring(0, StrCookie1.IndexOf(";"));
            myWebRequest1.CookieContainer.Add(new Cookie("LWSSO_COOKIE_KEY", StrCookie1) { Domain = target.Host });
            //Then the QCSession cookie
            string StrCookie2 = StrCookie.Substring(StrCookie.IndexOf("QCSession=") + 10);
            StrCookie2 = StrCookie2.Substring(0, StrCookie2.IndexOf(";"));
            myWebRequest1.CookieContainer.Add(new Cookie("QCSession", StrCookie2) { Domain = target.Host });
            //Then the ALM_USER cookie
            string StrCookie3 = StrCookie.Substring(StrCookie.IndexOf("ALM_USER=") + 9);
            StrCookie3 = StrCookie3.Substring(0, StrCookie3.IndexOf(";"));
            myWebRequest1.CookieContainer.Add(new Cookie("ALM_USER", StrCookie3) { Domain = target.Host });
            //And finally the XSRF-TOKEN cookie
            string StrCookie4 = StrCookie.Substring(StrCookie.IndexOf("XSRF-TOKEN=") + 12);
            StrCookie4 = StrCookie4.Substring(0, StrCookie4.IndexOf(";"));
            myWebRequest1.CookieContainer.Add(new Cookie("XSRF-TOKEN", StrCookie4) { Domain = target.Host });
            //We then send our webrequest and collect the webresponse
            WebResponse webResponse1 = myWebRequest1.GetResponse();
            StreamReader reader = new StreamReader(webResponse1.GetResponseStream());
        }
