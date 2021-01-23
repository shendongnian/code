    string attachment = string.Empty;
    HttpResponse Response = HttpContext.Current.Response;
    Response.Clear();
    Response.ClearHeaders();
    Response.ClearContent();
    Response.AddHeader("content-disposition", "attachment; filename=export.csv");
    Response.ContentType = "text/csv";
    Response.Write(sb.ToString());
    Response.End();
