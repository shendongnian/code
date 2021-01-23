    public byte[] GetByteArray(string sourcePath)
        {
            byte[] outBytes = null;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    outBytes = wc.DownloadData(sourcePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return outBytes;
        }
