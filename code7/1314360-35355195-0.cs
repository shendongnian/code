    using(HttpWebResponse WebResponse = (HttpWebResponse)url.GetResponse())
    {
                int status = (int)WebResponse.StatusCode;
    
                using(Stream ST = WebResponse.GetResponseStream())
                using(StreamReader STreader = new StreamReader(ST))
                    string RR = STreader.ReadToEnd();
    }
