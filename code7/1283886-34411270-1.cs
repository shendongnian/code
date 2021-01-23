			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "text/plain";
            request.Timeout = -1; //Infinite wait for the response.
            // Get the file information object.
            FileInfo fileInfo = new FileInfo("C:\\Test\\uploadFile.dat");
            // Set the file content length.
            request.ContentLength = fileInfo.Length;
            // Get the number of segments the file will be uploaded to the stream.
            int segments = Convert.ToInt32(fileInfo.Length / (1024 * 4));
            // Get the source file stream.
            using (FileStream fileStream = fileInfo.OpenRead())
            {
                // Create 4KB buffer which is file page size.
                byte[] tempBuffer = new byte[1024 * 4];
                int bytesRead = 0;
                // Write the source data to the network stream.
                using (Stream requestStream = request.GetRequestStream())
                {
                    // Loop till the file content is read completely.
                    while ((bytesRead = fileStream.Read(tempBuffer, 0, tempBuffer.Length)) > 0)
                    {
                        // Write the 4 KB data in the buffer to the network stream.
                        requestStream.Write(tempBuffer, 0, bytesRead);
                        // Update your progress bar here using segment count.
                    }
                }
            }
            // Post the request and Get the response from the server.
            using (WebResponse response = request.GetResponse())
            {
                // Request is successfully posted to the server.
            }
