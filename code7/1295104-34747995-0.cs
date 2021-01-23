    protected void OpenPDFFile(string filePath)
    {
           //set the appropriate ContentType.
            Response.ContentType = "Application/pdf";
           //write the file to  http content output stream.
            Response.WriteFile(filePath);
            Response.End();
    }
