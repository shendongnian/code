    public string HttpCall(string NvpRequest)
    {
        string url = pEndPointURL;
        string strPost = NvpRequest + "&" + buildCredentialsNVPString();
        strPost = strPost + "&BUTTONSOURCE=" + HttpUtility.UrlEncode(BNCode);
        var byteStr = Encoding.UTF8.GetBytes(strPost);
        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
        objRequest.Timeout = Timeout;
        objRequest.Method = "POST";
        objRequest.ContentLength = byteStr.Length;
        try
        {
           using(var str = objRequest.GetRequestStream())
               str.Write(byteStr, 0, byteStr.Length);
        }
        catch (Exception e)
        {
      // Log the exception.
          WingtipToys.Logic.ExceptionUtility.LogException(e, "HttpCall in PayPalFunction.cs");
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
    
