    public string HttpCall(string NvpRequest) //CallNvpServer
    {
        string url = pendpointurl;
    
        //To Add the credentials from the profile
        string strPost = NvpRequest + "&" + buildCredentialsNVPString();
    	strPost = strPost + "&BUTTONSOURCE=" + HttpUtility.UrlEncode( BNCode );
    
        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
        objRequest.Timeout = Timeout;
        objRequest.Method = "POST";
        objRequest.ContentLength = strPost.Length;
    
        try
        {
            using (StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream()))
            {
                myWriter.Write(strPost);
            }
        }
        catch (Exception e)
        {
            /*
            if (log.IsFatalEnabled)
            {
                log.Fatal(e.Message, this);
            }*/
        }
    
        //Retrieve the Response returned from the NVP API call to PayPal
        
    
        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        string result;
        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        {
            result = sr.ReadToEnd();
        }
    
        //Logging the response of the transaction
        /* if (log.IsInfoEnabled)
         {
             log.Info("Result :" +
                       " Elapsed Time : " + (DateTime.Now - startDate).Milliseconds + " ms" +
                      result);
         }
         */
        return result;
    }
