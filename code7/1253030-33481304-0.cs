        using (var client = new System.Net.WebClient())
        {
	        WebProxy proxy = new WebProxy("localproxyIP:8080", true);
	        proxy.Credentials = new NetworkCredential("domain\\user", "password");
            WebRequest.DefaultWebProxy = proxy;
            client.Proxy = proxy;
            var values = new System.Collections.Specialized.NameValueCollection();
            //values["v"] = "1";
            //values["t"] = "event";
            //values["tid"] = trackingID;
            //values["cid"] = clientID;
            //values["ec"] = eventCategory.ToString();
            //values["ea"] = eventAction.ToString();
            //values["el"] = eventAction.ToString();
            var endpointAddress = "http://www.google-analytics.com/collect";
            var response = client.UploadValues(endpointAddress, values);
            var responseString = System.Text.Encoding.Default.GetString(response);
        }
