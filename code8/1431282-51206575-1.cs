                string URL = "http://localhost:xxxxx/api/values";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "DELETE";
                request.ContentType = "application/json";
                string data = Newtonsoft.Json.JsonConvert.SerializeObject("your body parameter value");
                request.ContentLength = data.Length;
                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                requestWriter.Write(data);
                requestWriter.Close();
    
                try
                {
                    WebResponse webResponse = request.GetResponse();
                    Stream webStream = webResponse.GetResponseStream();
                    StreamReader responseReader = new StreamReader(webStream);
                    string response = responseReader.ReadToEnd();
    
                    responseReader.Close();
                }
                catch
                {
    
                }
