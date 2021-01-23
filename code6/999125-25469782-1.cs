    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
    writer.Write("<html><head></head><body>Invoice 1></body></html>");
    writer.Flush();
    writer.Dispose();
    System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Html);
    System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, ct);
    attach.ContentDisposition.FileName = "myFile.html";
    ms.Close();
