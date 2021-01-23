    FontFactory.Register("c:/windows/fonts/arabtype.TTF"); 
    StyleSheet style = new StyleSheet();
    style.LoadTagStyle("body", "face", "%NAME OF ARABIC FONT%");
    style.LoadTagStyle("body", "encoding", BaseFont.IDENTITY_H);
    using (Document document = new Document(PageSize.A4, 80f, 80f, -2f, 35f)) {
      PdfWriter writer = PdfWriter.GetInstance(
        document, Response.OutputStream
      );
      document.Open();
      foreach(IElement element in HTMLWorker.ParseToList(
          new StringReader(%VARIABLE CONTAINING YOUR RAW HTML%.ToString()), style))
      {
        document.Add(element);
      }
    }
