    var fileInfo = new FileInfo(filePath);
    Response.Clear();
    Response.Buffer = true;
    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
    Response.AddHeader("Content-Length", fileInfo.Length.ToString(CultureInfo.InvariantCulture));
    Response.ContentType = "application/octet-stream";
    Response.BinaryWrite(File.ReadAllBytes(fileInfo.FullName));
    Response.Flush();
    Response.End();
