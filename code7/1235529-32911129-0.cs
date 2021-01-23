    HttpResponseMessage response = new HttpResponseMessage();
    response.Content = new PushStreamContent(async (stream, content, context) => 
      {
        var pdf = await PdfFileModel.PdfDbOps.QueryAsync(p => p.Id == pdfFileId);
        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        {
          FileName = pdf.Filename,
          DispositionType = "attachment"
        };
        PdfOperations.PdfToImages(pdf.Data, 500).First().Save(stream, ImageFormat.Png);
      }, "image/png");
    return response;
