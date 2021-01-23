    int byteCount
    byte[] buffer = new byte[2048]; // read in chunks of 2KB
    Stream responseStream= Response.GetResponseStream();
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
    
    while ((byteCount = responseStream.Read(buffer, 0, buffer.Length)) > 0)
    {
        Response.OutputStream.Write(buffer, 0, byteCount);    
    }
    
    Response.Flush();
    Response.Close();
    Response.End();
