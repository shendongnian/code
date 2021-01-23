    using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
    {
        var str = webResponse.GetResponseStream();
        var inBuf = new byte[webResponse.ContentLength];
        var bytesToRead = Convert.ToInt32(inBuf.Length);
        var bytesRead = 0;
        while (bytesToRead > 0)
        {
            var n = str.Read(inBuf, bytesRead, bytesToRead);
            if (n == 0) break;
            bytesRead += n;
            bytesToRead -= n;
        }
        var fstr = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
        fstr.Write(inBuf, 0, bytesRead);
        fstr.Close();
    }
