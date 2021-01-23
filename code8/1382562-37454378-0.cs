            private void generatepdf(byte[] byteImage)
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(byteImage);
                image.ScalePercent(0.3f * 100);
                using (MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    Document document = new Document(PageSize.A4, 188f, 88f, 10f, 10f);
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
    
                    string text1 = "before image";
                    Paragraph text1Title = new Paragraph(text1);
    
                    string text2 = "after image";
                    Paragraph text2Title = new Paragraph(text2);
    
                    document.Open();
                    document.Add(text1Title);
                    document.Add(image);
                    document.Add(text2Title);
                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
    
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=test.pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                }
            }
