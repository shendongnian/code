    string fileName = "\\\\myServer\\folder\\file.pdf";
    byte[] fileContent = System.IO.File.ReadAllBytes(fileName);
    context.Response.Clear();
    context.Response.ClearHeaders();
    context.Response.ClearContent();
    context.Response.ContentType = "application/pdf";
    context.Response.AddHeader("Content-Disposition", "attachment;filename=" + System.IO.Path.GetFileName(fileName));
    context.Response.AddHeader("Content-Length", fileContent.Length.ToString());
    context.Response.BinaryWrite(fileContent);
