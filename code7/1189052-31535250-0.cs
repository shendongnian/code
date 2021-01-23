    private string MakeRequest(string uri, string jsnPostData, string method)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            if (request != null)
            {
                request.Method = method;
                request.Timeout = 2000000;
                request.ContentType = "application/json";
                request.KeepAlive = true;
    
                byte[] data = Encoding.UTF8.GetBytes(jsnPostData);
    
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(data, 0, data.Length);
                dataStream.Close();
    
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
    
                return result;
            }
            else
                return "";
        }
        catch (Exception ex)
        {
            Response.Write("<b>Error :</b>" + ex.Message + "</br>");
            return "";
        }
    }
