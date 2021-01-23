    [System.Web.Http.HttpPost]
    public HttpResponseMessage getPDF2(PDFViewModel pvm)
    {
        ExportService exsv = new ExportService();
        byte[] data = exsv.getPDF(pvm);
    
        Response response = Request.CreateResponse(HttpStatusCode.OK);
        response.Buffer = false;
        response.Clear();
        response.ClearContent();
        //response.ClearHeaders(); //You want the 200 OK Headers
        response.ContentType = "Application/octet-stream";
        response.AppendHeader("Content-Disposition", "attachment; filename=test.pdf" );
        response.BinaryWrite(data);
        response.Flush();
        response.End(); //I don't know if you need this
        return response;
    }
