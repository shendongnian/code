      protected void Page_Load(object sender, EventArgs e)
    {
        string ForChecksum = string.Format("Sbi_txn_id={2}|arn={0}|amount={1}", "08072016012003001", "1", "1234567890");
        DoubleVerificationCheck(ForChecksum.Trim());
    }
    public string DoubleVerificationCheck(string data)
    {
        NameValueCollection requestNameValue = new NameValueCollection();
        string postData = "encdata=" + data + "|merchant_code=XYZ";
        NameValueCollection nameValue = new NameValueCollection();
        nameValue.Add("merchant_code", "XYZ");
        nameValue.Add("encdata", data);
        string responseMsg = PostRequest("https://merchant.Payemtgateway.com/doubleverification.htm", nameValue);
       return responseMsg;
      
    }
    public static string PostRequest(string uri, NameValueCollection pairs)
    {
        byte[] response = null;
        using (WebClient client = new WebClient())
        {
            response = client.UploadValues(uri, pairs);
        }
        return System.Text.Encoding.UTF8.GetString(response);
    }
