    void CallPostMethod()
        {
            // Restful service URL
            string url = 
	     “http://localhost/wcfrestbased/myservice.svc/PostSampleMethod/New“;
            // declare ascii encoding
            ASCIIEncoding encoding = new ASCIIEncoding();
            string strResult = string.Empty;
            // sample xml sent to Service & this data is sent in POST
            string SampleXml = @”<parent>” +
                    “<child>” +
                        “<username>username</username>” +
                        “<password>password</password>” +
                    “</child>” +
                  “</parent>”;
            string postData = SampleXml.ToString();
            // convert xmlstring to byte using ascii encoding
            byte[] data = encoding.GetBytes(postData);
            // declare httpwebrequet wrt url defined above
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            // set method as post
            webrequest.Method = “POST”;
            // set content type
            webrequest.ContentType = “application/x-www-form-urlencoded”;
            // set content length
            webrequest.ContentLength = data.Length;
            // get stream data out of webrequest object
            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // declare & read response from service
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            // set utf8 encoding
            Encoding enc = System.Text.Encoding.GetEncoding(”utf-8?);
            // read response stream from response object
            StreamReader loResponseStream = 
		new StreamReader(webresponse.GetResponseStream(), enc);
            // read string from stream data
            strResult = loResponseStream.ReadToEnd();
            // close the stream object
            loResponseStream.Close();
            // close the response object
            webresponse.Close();
            // below steps remove unwanted data from response string
            strResult = strResult.Replace(”</string>”, “”);
                strResult = strResult.Substring(strResult.LastIndexOf(’>
