    string filename = Server.MapPath("~/PDF/" + Url_SupplierId + ".pdf");
    document.Save(filename);
    Response.Clear();
    Response.ClearContent();
    Response.ClearHeaders();
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
    Response.End();
    File.Delete(filename);
