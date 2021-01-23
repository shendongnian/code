            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://testgw.gopay.cz/api/oauth2/token");
            request.Method = "POST";
            request.Accept = "application/json";            
            string credentials = String.Format("{0}:{1}", "testid", "testecret");
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(credentials);
            string base64 = Convert.ToBase64String(bytes);
            string authorization = String.Concat("basic ", base64);
            request.Headers.Add("Authorization", authorization);
            request.ContentType = "application/x-www-form-urlencoded";
            
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string data = "grant_type=client_credentials&scope=payment-create";
                streamWriter.Write(data);
            }
            WebResponse wr = request.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
            string content = reader.ReadToEnd();
            var json = "[" + content + "]"; // change this to array
            var objects = JArray.Parse(json); // parse as array  
            foreach (JObject o in objects.Children<JObject>())
            {
                foreach (JProperty p in o.Properties())
                {
                    string name = p.Name;
                    string value = p.Value.ToString();
                }
            }
