    // Copy file to byte array
    byte[] file = new byte[memStream.Length];
    memStream.Read(file, 0, file.Length);
    
    // Send file
    Response.ContentType = "application/octet-stream";
    Response.AddHeader("content-disposition", "inline;filename=" + saveAsFileName);
    Response.Buffer = true;
    Response.Clear();
    Response.BinaryWrite(file);
    Response.End();
    // Return success
    return new HttpStatusCodeResult(HttpStatusCode.OK);
