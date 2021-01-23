       foreach (String item in DATA)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "POST";
                request.ContentType = "application/json";
    
                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
    
                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    Object routes_list =
                         json_serializer.DeserializeObject(item);
                    requestWriter.Write(item);
                }
    
    
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    response.Add(responseReader.ReadToEnd());
            
                }
            }
