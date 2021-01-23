            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.Headers = headers;
            request.Headers.Add("Content-Encoding", "gzip");
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(batchCollection);
            using (Stream requestStream = request.GetRequestStream())
            {
                var buffer = Encoding.UTF8.GetBytes(json);
                using (GZipStream compressionStream = new GZipStream(requestStream, CompressionMode.Compress, true))
                {
                    compressionStream.Write(buffer, 0, buffer.Length);
                }
            }
            var response = (HttpWebResponse)request.GetResponse();
            BatchCollection batchOut = null;
            using (Stream responseStream = response.GetResponseStream())
            {
                var reader = new StreamReader(responseStream);
                var jsonOut = reader.ReadToEnd();
                reader.Close();
                batchOut = JsonConvert.DeserializeObject<BatchCollection>(jsonOut);
            }
            return batchOut;
