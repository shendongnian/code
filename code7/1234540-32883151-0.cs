      HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pwmaffr2:8443/remote/system.delete?names=" + DeviceName + "");
                        request.Headers.Add("AUTHORIZATION", "Basic YTph");
                        request.ContentType = "text/html";
    
                        request.Credentials = new NetworkCredential(Username, Password);
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                        request.PreAuthenticate = true;
                        request.Method = "GET";
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        );
    
                        StreamReader stream = new StreamReader(response.GetResponseStream());
                        string X = stream.ReadToEnd();
