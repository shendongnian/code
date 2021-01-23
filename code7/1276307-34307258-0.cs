    using NReco.ImageGenerator;
    using NReco.PdfGenerator;
    //아래 주석들을 잘 여닫으면 jpg로 저장할 수 있다.
      /*
      'C:\inetpub\wwwroot\...\bin\wkhtmltopdf.exe' 경로에 대한 액세스가 거부되었습니다.
      'C:\inetpub\wwwroot\...\bin\msvcp120.dll' 경로에 대한 액세스가 거부되었습니다. 
      'C:\inetpub\wwwroot\...\bin\msvcr120.dll' 경로에 대한 액세스가 거부되었습니다. 
      위 세 파일을 해당 경로에 넣어 주면 정상 작동한다.
      */
      string article_no = Request["article_no"];
      //string[] urlArray = Request["url"].Split('/');
      //string textfilename = Guid.NewGuid().ToString() + ".html";
      //string url = urlArray[0] + "//" + urlArray[2] + "/storage/print/" + textfilename;
      //string textfilepath = Server.MapPath("/storage/print/" + textfilename);
      string html = "<html>"+HttpUtility.UrlDecode(Request["html"])+"</html>";
      //string jpgpath = Server.MapPath("/storage/print/") + article_no + ".jpg";
      string pdfpath = Server.MapPath("/storage/print/") + article_no + ".pdf";
      try
      {
        //byte[] jpg;
        byte[] pdf;
        //if (System.IO.File.Exists(jpgpath))
        if (System.IO.File.Exists(pdfpath))
        {
          //jpg = System.IO.File.ReadAllBytes(jpgpath);
          pdf = System.IO.File.ReadAllBytes(pdfpath);
        }
        else
        {
          #region Transform the HTML into PDF
          //System.IO.File.WriteAllText(textfilepath, html);
          //jpg
          /*
          var htmlToImageConv = new HtmlToImageConverter();
          jpg = htmlToImageConv.GenerateImage(html, ImageFormat.Jpeg);
          //jpg = htmlToImageConv.GenerateImageFromFile(textfilepath, ImageFormat.Jpeg);
          */
      //pdf
      var htmlToPdf = new HtmlToPdfConverter();
          pdf = htmlToPdf.GeneratePdf(html);
          //htmlToPdf.GeneratePdfFromFile(url, null, pdfpath);
          System.IO.File.WriteAllBytes(pdfpath, pdf);
          //System.IO.File.Delete(textfilepath);
          #endregion
        }
        #region Return the pdf file
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        //Response.AddHeader("Content-Disposition", string.Format("attachment;filename={1}.jpg; size={0}", jpg.Length, article_no));
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={1}.pdf; size={0}", pdf.Length, article_no));
        Response.BinaryWrite(pdf);
        Response.Flush();
        Response.End();
        #endregion
