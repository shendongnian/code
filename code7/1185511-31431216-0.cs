      int count=1;
     foreach (DataListItem dli in dl.Items)
        {
         string barcode = ((Label)dli.FindControl("lblBarCode")).Text;
         string studcode = ((Label)dli.FindControl("lblStudCode")).Text;
         if (count == 1)
          {
             PdfPCell cell0 = new PdfPCell();
             code128.Code = "*" + barcode + "*";
             iTextSharp.text.Image image128111 = code128.CreateImageWithBarcode(cb, null, null);
             cell0.AddElement(image128111);
             Paragraph p = new Paragraph("" + studcode + "");
             p.Alignment = Element.ALIGN_CENTER;
             cell0.AddElement(p);
             BarCodeTable.AddCell(cell0);
             BarCodeTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
             BarCodeTable.AddCell(new Phrase(new Phrase("", times11)));
             count++;
          }
          else if (count == 2)
           {
              PdfPCell cell1 = new PdfPCell();
              code128.Code = "*" + barcode + "*";
              iTextSharp.text.Image image1281 = code128.CreateImageWithBarcode(cb, null, null);
              cell1.AddElement(image1281);
              Paragraph p1 = new Paragraph("" + studcode + "");
              p1.Alignment = Element.ALIGN_CENTER;
              cell1.AddElement(p1);
              BarCodeTable.AddCell(cell1);
              BarCodeTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
              BarCodeTable.AddCell(new Phrase(new Phrase("", times11)));
              count++;
            }
           else if(count==3)
            {
                PdfPCell cell2 = new PdfPCell();
                code128.Code = "*" + barcode + "*";
                iTextSharp.text.Image image1282 = code128.CreateImageWithBarcode(cb, null, null);
                cell2.AddElement(image1282);
                Paragraph p2 = new Paragraph("" + studcode + "");
                p2.Alignment = Element.ALIGN_CENTER;
                cell2.AddElement(p2);
                BarCodeTable.AddCell(cell2);
                count = 1;
             }
           }
         doc.Add(BarCodeTable);
