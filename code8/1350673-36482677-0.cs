        public static string sContent;
        public static Int32 OnWriteData(Byte[] buf, Int32 size, Int32 nmemb, Object extraData)
        {
            string encoding = "UTF-8";
            sContent += System.Text.Encoding.GetEncoding(encoding).GetString(buf);
            return size * nmemb;
        }
