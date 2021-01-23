    public static string HttpPostWebRequest(string requestUrl, int timeout, string requestXML, bool isPost, string encoding, out string msg)
        {
            msg = string.Empty;
            string result = string.Empty;
            try
            {
                byte[] bytes = System.Text.Encoding.GetEncoding(encoding).GetBytes(requestXML);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Referer = requestUrl;
                request.Method = isPost ? "POST" : "GET";
                request.ContentLength = bytes.Length;
                request.Timeout = timeout * 1000;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding(encoding));
                    result = reader.ReadToEnd();
                    reader.Close();
                    responseStream.Close();
                    request.Abort();
                    response.Close();
                    return result.Trim();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message + ex.StackTrace;
            }
            return result;
        }
