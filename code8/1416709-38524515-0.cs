    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename=file_name.pdf");
    Response.TransmitFile(file_path);
    Response.End(); 
