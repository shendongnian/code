    private void Download() {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition","attachment;filename=sample.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        // stream to store generated document
        var memoryStream = new MemoryStream();
        // generate document
        CreatePdf(memoryStream);
        //pass the stream to the response output stream
        Response.OutputStream.Write(memoryStream.GetBuffer(),0,memoryStream.Length);
    }
