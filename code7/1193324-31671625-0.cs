    public class _events : PdfPageEventHelper
        {
            public _events(string TemplateName,string ImgUrl)
            {
                this.TempName = TemplateName;
                this.ImageUrl = ImgUrl;
            }
            private string TempName = string.Empty;
            private string ImageUrl = string.Empty;
    
            public override void OnEndPage(PdfWriter writer, Document doc)
            {
                Paragraph PTempName = new Paragraph("Template Name:" + TempName, FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL));
                Paragraph PDate = new Paragraph(DateTime.UtcNow.ToShortDateString(), FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL));
                
                //adding image (logo)
    
                string imageURL = "http://108.168.203.227/PoologicApp/Content/Bootstrap/images/logo.png";//HttpContext.Current.Server.MapPath("~/Content/images.jpg");
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                //Resize image depend upon your need
                jpg.ScaleToFit(70f, 120f);
                //Give space before image
                //jpg.SpacingBefore = 10f;
                //Give some space after the image
                jpg.SpacingAfter = 1f;
                jpg.Alignment = Element.ALIGN_TOP;
    
    
                PTempName.Alignment = Element.ALIGN_TOP;
                PDate.Alignment = Element.ALIGN_TOP;
    
                PdfPTable headerTbl = new PdfPTable(3);
    
                headerTbl.TotalWidth = 600;
    
                headerTbl.HorizontalAlignment = Element.ALIGN_TOP;
    
                PdfPCell cell11 = new PdfPCell(PTempName);
                PdfPCell cell3 = new PdfPCell(PDate);
                PdfPCell cell2 = new PdfPCell(jpg);
                cell2.Border = 0;
               cell11.Border = 0;
               cell3.Border = 0;
    
                cell11.PaddingLeft = 10;
                cell3.PaddingLeft = 10;
                cell2.PaddingLeft = 10;
                headerTbl.AddCell(cell11);
                headerTbl.AddCell(cell3);
                headerTbl.AddCell(cell2);
    
                headerTbl.WriteSelectedRows(0, -1, doc.LeftMargin, doc.PageSize.Height - 4, writer.DirectContent);
                
    
            }
        }
