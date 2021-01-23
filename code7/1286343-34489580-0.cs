    class MyHeaderFooterEvent : PdfPageEventHelper {
      Font FONT = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD);
      
      public override void OnEndPage(PdfWriter writer, Document document) {
        PdfContentByte canvas = writer.DirectContent;
        ColumnText.ShowTextAligned(
          canvas, Element.ALIGN_LEFT,
          new Phrase("Header", FONT), 10, 810, 0
        );
        ColumnText.ShowTextAligned(
          canvas, Element.ALIGN_LEFT,
          new Phrase("Footer", FONT), 10, 10, 0
        );
      }
    }
