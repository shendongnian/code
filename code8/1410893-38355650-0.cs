    using(WebClient client = new WebClient())
    {
        var reqparm = new System.Collections.Specialized.NameValueCollection();
        reqparm.Add("x_login", ""); // You're sending the key with en empty value
        reqparm.Add("x_line_item", Eval("Desc") );
        byte[] responsebytes = client.UploadValues("https://demo.bank.com/payment", "POST", reqparm);
        string responsebody = Encoding.UTF8.GetString(responsebytes);
    }
