    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
    reStream.CopyTo(Response.OutputStream);
    Response.Flush();
    Response.Close();
    Response.End();
