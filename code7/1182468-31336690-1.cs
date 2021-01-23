    var ts = ((long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds) / 1000;
    Response.ContentType = "text/plain";
    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(ts.ToString());
    Response.OutputStream.Write(bytes, 0, bytes.Length);
    Response.Flush();
    //now signal the httpapplication to stop processing the request.
    HttpContext.Current.ApplicationInstance.CompleteRequest();
