    try
    {
        doc.LoadXml(xmlData);
        context.Response.ContentType = "text/xml";
        context.Response.Write(xmlData);
    }
    catch (Exception e)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write(e.Message);
    }
