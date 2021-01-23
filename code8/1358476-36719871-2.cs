    public void OnPostInfoClick(object sender, System.EventArgs e)
    {
        string strId = "demo";
        string strName = "password";
        string firstname = "John";
        string lastname = "Smith";
        ASCIIEncoding encoding = new ASCIIEncoding();
        string postData = "userid=" + strId;
        postData += ("&username=" + strName);
        postData += ("&firstname=" + firstname);
        postData += ("&lastname=" + lastname);
        byte[] data = encoding.GetBytes(postData);
        HttpWebRequest myRequest =
          (HttpWebRequest)WebRequest.Create("http://www.mywebpage.com/casting/include/callremote.asp");
        myRequest.Method = "POST";
        myRequest.ContentType = "application/x-www-form-urlencoded";
        myRequest.ContentLength = data.Length;
        Stream newStream = myRequest.GetRequestStream();
        newStream.Write(data, 0, data.Length);
        newStream.Close();
    }
