    string url = "http://localhost:50327/Service1.svc/data/"+input; 
                        string strResult = string.Empty;
                        // declare httpwebrequet wrt url defined above
                        HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
                        // set method as post
                        webrequest.Method = "GET";
                        // set content type
                        webrequest.ContentType = "application/json"; //x-www-form-urlencoded”;
                        // declare & read response from service
                        HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                        // set utf8 encoding
                        Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                        // read response stream from response object
                        StreamReader loResponseStream = new StreamReader
            				(webresponse.GetResponseStream(), enc);
                        // read string from stream data
                        strResult = loResponseStream.ReadToEnd();
                        // close the stream object
                        loResponseStream.Close();
                        // close the response object
                        webresponse.Close();
                        // assign the final result to text box
                        result = strResult;
                        lbResult.Text = strResult;
