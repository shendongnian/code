    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
    response.ClearContent();
    response.Clear();
    response.ContentType = "application/pdf";
    response.AddHeader("Content-Disposition", "attachment; filename=" + strSessVar + ";");
    response.End();
