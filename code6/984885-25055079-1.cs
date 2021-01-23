        internal static HttpWebRequest Request(string url, string action, string doc)
        {
            var soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(doc);
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            webRequest.Host = "wsrvc1.propartner.ee";
            using (var stream = webRequest.GetRequestStream())
            {
                soapEnvelop.Save(stream);
            }
            return webRequest;
        }
