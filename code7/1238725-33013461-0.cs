    HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
                objRequest.Timeout = Timeout;
                objRequest.Method = "POST";
               objRequest.ContentType = "application/json";
                objRequest.ContentLength = strPost.Length;
    string strPost = "{\"account_id\":\"528754\",\"client_id\":\"2544544\",\"client_secret\":\"0454a547\",\"access_token\":\"xxxxxx\",\"amount\":\"5\",\"short_description\":\"messages\",\"type\":\"service\",\"currency\":\"CAD\",\"redirect_uri\":\"https://www.mywebsite.com/sucess.aspx\"}"
                try
                {
                    using (StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream()))
                    {
                        myWriter.Write(strPost);
                        myWriter.Flush();
                        myWriter.Close();
                    }
                }
                catch (Exception e)
                {
                }
    
    
                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                string result;
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }
    
    
                return result;
