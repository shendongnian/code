    var cd = new System.Net.Mime.ContentDisposition
    {
        FileName = "filename.xml", 
        Inline = false
    };
    Response.AppendHeader("Content-Disposition", cd.ToString());
