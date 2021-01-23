    Byte[] bytes = ImageToByteArray(System.Drawing.Image.FromFile(@"D:\Test\Sample1.png"));
             //Converted Image to byte[] 
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(document, Response.OutputStream);
                document.Open();     
                byte[] imageBytes = bytes;
                ms.Write(bytes, 0, bytes.Length);
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageBytes);
                if (image.Height > image.Width)
                {
                    float percentage = 0.0f;
                    percentage = 700 / image.Height;
                    image.ScalePercent(percentage * 100);
                }
                else
                {
                    float percentage = 0.0f;
                    percentage = 140 / image.Width;
                    image.ScalePercent(percentage * 100);
                }
                if (!document.IsOpen())
                {
                    document.Open();
                }
                document.Add(image);
                var htmlWorker = new HTMLWorker(document);
                string message="hi";
                using (var sr = new StringReader(message))
                {
                    htmlWorker.Parse(sr);
                }
                bytes = ms.ToArray();
                document.Close();
            }
            Response.ContentType = "application/pdf";
            string pdfName = "User";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
            Response.Buffer = true;
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
            Response.Flush();
     
