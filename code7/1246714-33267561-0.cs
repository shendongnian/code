        [WebMethod]
        public void UploadFile(string FileName, byte[] buffer, long Offset, out bool UploadOK, out string msg)
        {
            Log(string.Format("Upload File {0}. Offset {1}, Bytes {2}...", FileName, Offset, buffer.Length));
            UploadOK = false;
            try
            {
                // setting the file location to be saved in the server. 
                // reading from the web.config file 
                string FilePath = Path.Combine( ConfigurationManager.AppSettings["upload_path"], FileName);
                if (Offset == 0) // new file, create an empty file
                    File.Create(FilePath).Close();
                // open a file stream and write the buffer. 
                // Don't open with FileMode.Append because the transfer may wish to 
                // start a different point
                using (FileStream fs = new FileStream(FilePath, FileMode.Open,
                    FileAccess.ReadWrite, FileShare.Read))
                {
                    fs.Seek(Offset, SeekOrigin.Begin);
                    fs.Write(buffer, 0, buffer.Length);
                }
                UploadOK = true;
                msg = "uploaded to " + FilePath;
                Log(string.Format("Sucessfully Uploaded to File {0}: {1}", FileName, msg));
            }
            catch (Exception ex)
            {
                //sending error:
                msg = "failed to upload: " + ex.Message;
                UploadOK = false;
                Log(string.Format("Failed Upload File {0}: {1}", EmlFileName, ex.Message));
            }
        }
