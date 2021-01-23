    public class RestServiceImpl : IRestServiceImpl
    {
        public string PostFileRest(Stream fileContents)
        {
            var httpRequest = HttpContext.Current.Request;
            var filePath = "C:\\file.xls";  //excel filePath for local
            var bites = httpRequest.TotalBytes;
            //Convert stream to byte array
            byte[] reqBytes = readRequest(fileContents, bites);
            byte[] decodedReqBytes = HttpUtility.UrlDecodeToBytes(reqBytes);
            string json = System.Text.Encoding.UTF8.GetString(reqBytes);
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
            MemoryStream stream = new MemoryStream(reqBytes);
            FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            stream.WriteTo(file);
            file.Close();
            stream.Close();
            return json ;
        }
        #region Convert Stream to byte array
        private byte[] readRequest(Stream fileContents, int bites)
        {
            System.IO.MemoryStream memStream = new System.IO.MemoryStream();
            int BUFFER_SIZE = bites;
            int iRead = 0;
            int idx = 0;
            Int64 iSize = 0;
            memStream.SetLength(BUFFER_SIZE);
            while (true)
            {
                byte[] reqBuffer = new byte[BUFFER_SIZE];
                try
                {
                    iRead = fileContents.Read(reqBuffer, 0, BUFFER_SIZE);
                }
                catch (System.Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                if (iRead == 0)
                {
                    break;
                }
                iSize += iRead;
                memStream.SetLength(iSize);
                memStream.Write(reqBuffer, 0, iRead);
                idx += iRead;
            }
            byte[] content = memStream.ToArray();
            memStream.Close();
            return content;
        }
        #endregion
    }
