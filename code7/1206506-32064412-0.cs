    if (mobile != null && mobile != string.Empty)
    {
        msgText = SMSContentSubject.Content.Replace("EMPID", EMPID).Replace("EMPNAME", EMPNAME).ToString();
    
        If(!string.IsNullorEmpty(msgText))
        {
        Uri requestUri = new Uri("http://www.myvaluefirst.com/smpp/sendsms" + "?username=medimanagecri&password=medimib2&to=" + mobile + "&udh=0&from=MEDIMA&text=" + msgText + "&dlr-url=");
        WebRequest webRequest = WebRequest.Create(requestUri);
        WebResponse response = webRequest.GetResponse();
        Stream responseStream = response.GetResponseStream();
        StreamReader streamReader = new StreamReader(responseStream);
        string text = streamReader.ReadToEnd();
        }
        }
