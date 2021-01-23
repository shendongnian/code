           //assuming this is set
            byte[] Data;
            string url = string.Format("{0};{1}" ,myServiceURL, "login");
            // Request
            HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create(url);
            wreq.Method = "POST";
            wreq.Proxy = WebProxy.GetDefaultProxy();
            (wreq as HttpWebRequest).Accept = "text/xml";
            if (Data != null && Data.Length > 0)
            {
                wreq.ContentType = "application/x-www-form-urlencoded";
                System.IO.Stream request = wreq.GetRequestStream();
                request.Write(Data, 0, Data.Length);
                request.Close();
            }
            WebResponse wrsp = wreq.GetResponse();
