        using (Stream writeStream = request.GetRequestStream())
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(doc.InnerXml);
            request.ContentLength = bytes.Length;
            writeStream.Write(bytes, 0, bytes.Length);
        }
