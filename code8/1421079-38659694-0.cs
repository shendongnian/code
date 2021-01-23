    Response.ClearContent();
    Response.ContentType = "Application/pdf";
    Response.AddHeader("Content-Disposition", "inline; filename=report.pdf");
    Response.WriteFile(Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), "report.pdf"));
    Response.Flush();
    Response.End();
