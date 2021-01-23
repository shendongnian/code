    var blob = container.GetBlobReferenceFromServer(option);
    
    var memStream = new MemoryStream();
    blob.DownloadToStream(memStream);
    
    Response.ContentType = blob.Properties.ContentType;
    Response.AddHeader("Content-Disposition", "Attachment;filename=" + option);
    Response.AddHeader("Content-Length", blob.Properties.Length.ToString());
    Response.BinaryWrite(memStream.ToArray());
