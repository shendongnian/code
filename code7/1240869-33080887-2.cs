        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        int bufferSize = 1;
        Response.Clear();
        Response.AppendHeader("Content-Disposition:", "attachment; filename=" +filename);
        Response.AppendHeader("Content-Length", resp.ContentLength.ToString());
        Response.ContentType = "application/download";
        byte[] ByteBuffer = new byte[bufferSize + 1];
        MemoryStream ms = new MemoryStream(ByteBuffer, true);
        Stream rs = req.GetResponse().GetResponseStream();
        byte[] bytes = new byte[bufferSize + 1];
        while (rs.Read(ByteBuffer, 0, ByteBuffer.Length) > 0)
        {
            Response.BinaryWrite(ms.ToArray());
            Response.Flush();
        }
