        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
        //byte[] file = File.ReadAllBytes(videoFilePath);
        using (var fileStream = new FileStream(videoFilePath, FileMode.Open))
        {
            Uri uri = new Uri("https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable&part=snippet,status");
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            request.Method = "POST";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + authToken);
            request.ContentLength = jsonBytes.Length;
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("X-Upload-Content-Length", fileStream.Length.ToString());
            request.Headers.Add("X-Upload-Content-Type", "video/*");
            string location = string.Empty;
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(jsonBytes, 0, jsonBytes.Length);
            }
            try
            {
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                    location = response.Headers["Location"];
                }
            }
            catch (WebException ex)
            {
                Response.Write(ex.ToString());
            }
            request = (HttpWebRequest) WebRequest.Create(location);
            request.Method = "PUT";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + authToken);
            request.ContentLength = fileStream.Length;
            request.ContentType = "video/*";
            using (Stream dataStream = request.GetRequestStream())
            {
                byte[] buffer = new byte[fileStream.Length];
                var data = fileStream.Read(buffer, 0, buffer.Length);
                dataStream.Write(buffer, 0, data);
                //dataStream.Write(file, 0, file.Length);
            }
            try
            {
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                }
            }
            catch (WebException ex)
            {
                Response.Write(ex.ToString());
            }
