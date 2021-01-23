    [HttpPost]
    public ActionResult MyMethod(MyViewModel model)
    {
         HttpResponseBase response = ControllerContext.HttpContext.Response;
    
        response.ContentType = "application/pdf";
        response.AppendHeader("Content-Disposition", "attachment;filename=yourpdf.pdf");
        FileStreamResult document = CreateDocument(model);
        //Write you document to response.OutputStream here
        document.FileStream.Seek(0, SeekOrigin.Begin);
        document.FileStream.CopyTo(response.OutputStream, document.FileStream.Length);
        response.Flush();
        return new EmptyResult();
    } 
