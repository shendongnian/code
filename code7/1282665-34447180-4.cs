    private void Update()
    {
    	if (contentDownloading)
        {
            byte[] buffer = new byte[1024 * 1024];
            if (totalDownloaded < contentLength)
            {
                if (networkStream.DataAvailable)
                {
                    read = (uint)networkStream.Read(buffer, 0, buffer.Length);
                    totalDownloaded += read;
                    fileStream.Write(buffer, 0, (int)read);
                }
                int percent = (int)((totalDownloaded/(float)contentLength) * 100);
                Debug.Log("Downloaded: " + totalDownloaded + " of " + contentLength + " bytes ..." + percent);
            }
            else
            {
                fileStream.Flush();
                fileStream.Close();
                client.Close();
                Debug.Log("Load Complete");
                LoadNextContent();
            }
         }
     }
                    
