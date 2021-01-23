     public void ExportToPdf(DataTable myDataTable)  
       {      
         Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);  
         try  
         {  
           PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);  
           pdfDoc.Open();  
           Chunk c = new Chunk("" + System.Web.HttpContext.Current.Session["CompanyName"] + "", FontFactory.GetFont("Verdana", 11));  
           Paragraph p = new Paragraph();  
           p.Alignment = Element.ALIGN_CENTER;  
           p.Add(c);  
           pdfDoc.Add(p);  
           string clientLogo = System.Web.HttpContext.Current.Session["CompanyName"].ToString();  
           clientLogo = clientLogo.Replace(" ", "");  
           string clogo = clientLogo + ".jpg";  
           string imageFilePath = System.Web.HttpContext.Current.Server.MapPath("../ClientLogo/" + clogo + "");  
           iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);  
           //Resize image depend upon your need   
           jpg.ScaleToFit(80f, 60f);  
           //Give space before image   
           jpg.SpacingBefore = 0f;  
           //Give some space after the image   
           jpg.SpacingAfter = 1f;  
           jpg.Alignment = Element.HEADER;  
           pdfDoc.Add(jpg);  
           Font font8 = FontFactory.GetFont("ARIAL", 7);  
           DataTable dt = myDataTable;  
           if (dt != null)  
           {  
             //Craete instance of the pdf table and set the number of column in that table  
             PdfPTable PdfTable = new PdfPTable(dt.Columns.Count);  
             PdfPCell PdfPCell = null;  
             for (int rows = 0; rows < dt.Rows.Count; rows++)  
             {  
               for (int column = 0; column < dt.Columns.Count; column++)  
               {  
                 PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), font8)));  
                 PdfTable.AddCell(PdfPCell);  
               }  
             }  
             //PdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table            
             pdfDoc.Add(PdfTable); // add pdf table to the document   
           }  
           pdfDoc.Close();  
           Response.ContentType = "application/pdf";  
           Response.AddHeader("content-disposition", "attachment; filename= SampleExport.pdf");  
           System.Web.HttpContext.Current.Response.Write(pdfDoc);  
           Response.Flush();  
           Response.End();  
           //HttpContext.Current.ApplicationInstance.CompleteRequest();  
         }  
         catch (DocumentException de)  
         {  
           System.Web.HttpContext.Current.Response.Write(de.Message);  
         }  
         catch (IOException ioEx)  
         {  
           System.Web.HttpContext.Current.Response.Write(ioEx.Message);  
         }  
         catch (Exception ex)  
         {  
           System.Web.HttpContext.Current.Response.Write(ex.Message);  
         }  
       }  
