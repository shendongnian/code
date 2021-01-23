    public void ProcessRequest(HttpContext context)
    {
        string fileName = context.Request.QueryString["file"];
        if(fileName == null || fileName == "")
        {
            throw new ArgumentException("The file argument cannot be null or empty");
        }
        // fetch file here from db/filesystem/other storage
        byte[] fileBytes = LoadFileBytes(fileName);
        context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
        context.Response.ContentType = "application/pdf";
        context.Response.BinaryWrite(fileBytes);
    }
