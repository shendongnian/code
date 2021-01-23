        WebClient wc = new WebClient();
                    wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    wc.Encoding = System.Text.Encoding.UTF8;
                    wc.UseDefaultCredentials = true;
                    string cRresultData = wc.UploadString(URI, "POST", CRreq);
                    //string cRresultData = wc.UploadString(URI,CRreq);
                    string cRresponse = "";
    
    this code gives me  500 Server error
