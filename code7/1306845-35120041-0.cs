            HttpClient http = new HttpClient();
            var response = await http.GetAsync(new Uri(_url));
            var buffer = await response.Content.ReadAsBufferAsync();
            byte[] byteArray = buffer.ToArray();
            string content = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                
            var xmlDoc = XDocument.Parse(content);
            return xmlDoc;
