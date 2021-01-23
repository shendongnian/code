            MemoryStream memStream = new MemoryStream();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Data.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            StringReader sr = new StringReader(Data);
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);            
            pdfDoc.Close();            
            Response.Write(pdfDoc);
            
            memStream.WriteTo(Response.OutputStream);
            memStream.Position = 0;
            var file = File(memStream, "application/pdf");
            Response.End();
            return file;
        }
