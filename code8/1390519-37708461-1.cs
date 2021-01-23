    <%@Page Language="C#" %>
    <%
        Response.ContentType = "application/javascript";
        Response.Cache.SetCacheability(HttpCacheability.Public);
        Response.Cache.SetExpires(DateTime.Now.AddHours(1));
    %>
    
    var imagePath = "<%= ResolveUrl("~/images/myimage.png") %>";
