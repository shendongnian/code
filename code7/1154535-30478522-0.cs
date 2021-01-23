    string oldFile = @"C:\...6166-21.pdf";
            string newFile = @"C:\...NEW.pdf";
    
            // open the reader
            PdfReader reader = new PdfReader(oldFile);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);
    
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
    
            // the pdf content
            PdfContentByte cb = writer.DirectContent;
    
            cb.SetColorStroke(iTextSharp.text.BaseColor.GREEN);
            cb.Circle(150f, 150f, 50f);
            cb.Stroke();
    
            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);
    
            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
