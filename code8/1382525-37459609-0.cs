            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            string mergedCredentials = string.Format("{0}:{1}", "username", "password");
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            string base64Credentials = Convert.ToBase64String(byteCredentials);
            request.Headers.Add("Authorization", "Basic " + base64Credentials);
            request.Method = "POST";
            request.ContentType = "application/xml";
            StreamReader reader = new StreamReader(fileName);
            string ret = reader.ReadToEnd();
            reader.Close();
            string postData = ret;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string result = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
