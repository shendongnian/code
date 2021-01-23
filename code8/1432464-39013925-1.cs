    public static byte[] Stamp(byte[] resource) {
      PdfReader reader = new PdfReader(resource);
      using (var ms = new MemoryStream()) {
        using (PdfStamper stamper = new PdfStamper(reader, ms)) {
          PdfContentByte canvas = stamper.GetOverContent(1);
          ColumnText.ShowTextAligned(
            canvas,
            Element.ALIGN_LEFT, 
            new Phrase("Hello people!"), 
            36, 540, 0
          );
        }
        return ms.ToArray();
      }
    }
