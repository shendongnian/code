    public string ReturnHtmlResponse(string url)
            {
            string result;
            var request = (HttpWebRequest)WebRequest.Create(url);
                
            var response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine((int)response.StatusCode);
            var encoding = Encoding.GetEncoding(response.CharacterSet);
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream,encoding);
            result = sr.ReadToEnd();
            
            sr.Close();
            stream.Close();
            response.Close();
    
            sr.Dispose();
            stream.Dispose();
            response.Dispose();
            
            return result;
            }
