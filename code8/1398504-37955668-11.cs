    private void Download() {
        Response.ContentType = "application/pdf;";
        Response.AddHeader("content-disposition","attachment;filename=sample.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        // stream to store generated document
        var output = new MemoryStream();
        // generate document
        CreatePdf(output);
        // pass the generated data to the response output stream
        Response.OutputStream.Write(output.GetBuffer(), 0, output.Length);
    }
