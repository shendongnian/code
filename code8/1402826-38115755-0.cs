    Here is a complete code: If any body needs.Make sure the image isn't large!!
    public byte [] GetImgByte (string ftpFilePath)
            {
                WebClient ftpClient = new WebClient();
                ftpClient.Credentials = new NetworkCredential(ftpUsername,ftpPassword);
                byte[] imageByte = ftpClient.DownloadData(ftpFilePath);
                return imageByte;
            }
            public static Bitmap ByteToImage(byte[] blob)
            {
                MemoryStream mStream = new MemoryStream();
                byte[] pData = blob;
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();
                return bm;
            }
