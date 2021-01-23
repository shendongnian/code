            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pathapi);
            request.Method = "POST";
            string postData = "grant_type=password";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;            
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                getreaderjson = reader.ReadToEnd();
            }
