    HttpResponse Response =HttpContext.Current.Response;
    Response.Clear();
    Response.SetCookie(cookie);
    Response.StatusCode = 200;// HttpStatusCode.OK;
    Response.ContentType = "applicaiton/json; charset=utf-8";
    Response.Write(MyPOCO);
    Response.End();
