    private void DownloadTheFile(string uri)
    {
        var outputFileName = "Platypus.exe";
        var webRequest = (HttpWebRequest)WebRequest.Create(uri);
        var webResponse = (HttpWebResponse)webRequest.GetResponse();
        string statusCode = webResponse.StatusCode.ToString();
        // From here on (including the CopyStream() method) derived from Jon Skeet's 
        // answer at http://stackoverflow.com/questions/411592/how-do-i-save-a-stream-to-a-file
        if (statusCode == "NoContent")
        {
            MessageBox.Show("You already have the newest available version.");
        }
        else
        {
            var responseStream = webResponse.GetResponseStream();
            using (Stream file = File.Create(outputFileName))
            {
                CopyStream(responseStream, file);
                MessageBox.Show(string.Format("New version downloaded to {0}", outputFileName));
            }
        }
    }
    
    public static void CopyStream(Stream input, Stream output)
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, len);
        }
    }
