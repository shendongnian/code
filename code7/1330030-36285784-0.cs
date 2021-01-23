    public Response Login(String usr, String pwd)
            {
                this.MyId++;
                Request model = new Request(id, usr, pwd);
                var http = (HttpWebRequest)WebRequest.Create(uri);
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] bytes = encoding.GetBytes(json);
    
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
    
                var response = http.GetResponse();
    
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                Response res= Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(content.ToString());
                return res;
                
            }
