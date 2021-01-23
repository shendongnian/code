    public ActionResult PdfDownload()
        {
            string TempFilePath = @"C:\Program Files\wkhtmltopdf\bin\myPDF.pdf";
            if (System.IO.File.Exists(TempFilePath))
            {
                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = "testPDF.pdf",
                    Inline = false,
                };
                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(TempFilePath, "application/pdf");
            }
            else
            {
                return null;
            }
        }
