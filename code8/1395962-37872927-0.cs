    public ActionResult DisplayPDF()
     {   
      byte[] byteArray = GetPdfFromDB();[Your byte array from db]
      MemoryStream pdfStream = new MemoryStream();
      pdfStream.Write(byteArray , 0,byteArray .Length);
      pdfStream.Position = 0;
      HttpContext.Response.AddHeader("content-disposition", 
      "attachment; filename=form.pdf");
      return new FileStreamResult(fileStream, "application/pdf");
    }
