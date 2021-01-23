        using (Stream writeStream = request.GetRequestStream())
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string response = String.Concat("arg=", HttpUtility.UrlEncode(doc.InnerXml))
            byte[] bytes = encoding.GetBytes(doc.InnerXml);
            //request.ContentLength = bytes.Length;
            writeStream.Write(bytes, 0, bytes.Length);
        }
