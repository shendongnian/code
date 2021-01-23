    using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(username, password);
                    client.UploadFile(ftpServer + "/" + Path.GetFileName(filepathAndName), filepathAndName);
                }
