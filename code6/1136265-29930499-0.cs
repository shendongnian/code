    public void ProcessRequest (HttpContext context)
    {
         // Build Document and Zip:
         BuildAndZipDocument(); 
         // Context:
         context.Response.ContentType = "application/zip";
         context.Response.AddHeader("content-disposition", "filename="Commodity.zip");
         zip.Save(context.Response.OutputStream);
         // Close:
         context.Response.End();
    }
