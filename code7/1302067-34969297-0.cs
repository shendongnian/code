     public string HttpCall(string NvpRequest)
        {
            string url = pEndPointURL;
    
            string strPost = NvpRequest + "&" + buildCredentialsNVPString();
            strPost = strPost + "&BUTTONSOURCE=" + HttpUtility.UrlEncode(BNCode);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            // Try using Tls11 if it doesnt works for you with Tls
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Timeout = Timeout;
            objRequest.Method = WebRequestMethods.Http.Post;
            objRequest.ContentLength = strPost.Length;
            try
            {
               
                using (StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream()))
                {
                    myWriter.Write(strPost.ToString());
                }
            }
            catch (Exception e)
            {
             
            }
    
            //Retrieve the Response returned from the NVP API call to PayPal. 
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            string result;
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
    
            return result;
        }
