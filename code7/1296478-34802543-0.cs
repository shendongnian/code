     if (isSaveToFTP)
            {
                using (WebClient webClient = new WebClient())
                {
                    Stream stream = new MemoryStream();
                    fileAttachment.Load(stream);
                    using (var reader = new StreamReader(stream))
                    {
                        byte[] buffer = Encoding.Default.GetBytes(reader.ReadToEnd());
                        WebRequest uploadFile = WebRequest.Create(ftpAddress + name + "/" + fileAttachment.Name);
                        uploadFile.Method = WebRequestMethods.Ftp.UploadFile;
                        uploadFile.Credentials = new NetworkCredential(username, password);
                        Stream reqStream = uploadFile.GetRequestStream();
                        reqStream.Write(buffer, 0, buffer.Length);
                        reqStream.Close();
                    }
                }
