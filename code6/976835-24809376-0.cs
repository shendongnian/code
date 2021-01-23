    while ((byteCount = resStream.Read(buffer, 0, buffer.Length)) > 0)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
        Response.OutputStream.Write(buffer, 0, byteCount);    
    }
    Response.Flush();
    Response.Close();
    Response.End();
