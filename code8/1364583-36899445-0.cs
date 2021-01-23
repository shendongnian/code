         using (var newPDF = new FileStream(outPutFile, FileMode.Create, FileAccess.ReadWrite))
         {
              PdfReader pdfReader = new PdfReader(reader);
              PdfStamper pdfStamper = new PdfStamper(pdfReader, newPDF);
    
              for (int page = 1; page <= pdfReader.NumberOfPages; page++)
              {
                   PdfContentByte pdfContent = pdfStamper.GetOverContent(page);
                   Rectangle mediabox = pdfReader.GetPageSize(page);  
    
                   pdfContent.BeginText();
                   pdfContent.ShowTextAligned(0, "someText", xLocation, mediabox.Height - yLocation , 0);
                   pdfContent.EndText();
               }
                            
               pdfStamper.Close();
          } 
