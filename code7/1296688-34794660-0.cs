        static void Concat(string targetPdf, string[] newPdfFiles)
        {
            using (FileStream stream = new FileStream(targetPdf, FileMode.Create))
            {
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4);
                PdfCopy pdf = new PdfCopy(pdfDoc, stream);
                pdfDoc.Open();
                foreach (string file in orderedlist)
                {
                    if (!(file.Contains("HR Policies and Procedures Guide")))
                    {
                        var newFileName = "\\\\file\\IT\\SK\\test\\" + file.Split('.')[0] + ".pdf";
                        PdfReader test = new PdfReader(newFileName);
                        pdf.AddDocument(test);
                        test.Dispose();
                        // Delete the individual pdf ..
                        System.IO.File.Delete(newFileName);
                    }
                }
            }
        }
