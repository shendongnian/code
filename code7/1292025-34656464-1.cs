    public interface IWriter { void Write(Stream stream); }
    public class TextAndImageWatermarker : IWriter 
    {
      public readonly string INPUT_PDF = "the_pdf_you_are_watermarking";
      // inner class for text watermark
      class TextWatermarkPdfPageEventHelper : PdfPageEventHelper
      {
          static readonly Font FONT = new Font(Font.FontFamily.HELVETICA, 40, Font.NORMAL, new GrayColor(0.75f));
          
          // write text SW to NE for odd pages, NW to SE for even pages
          public override void OnEndPage(PdfWriter writer, Document document)
          {
              ColumnText.ShowTextAligned(
                writer.DirectContentUnder,
                Element.ALIGN_CENTER, new Phrase("watermark (text or image) in existing pdf", FONT),
                300, 400, writer.PageNumber % 2 == 1 ? 60 : -60
              );
          }
      }
      
      // inner class for image watermark
      class ImageWatermarkPdfPageEventHelper : PdfPageEventHelper
      {
          // the image you use as a watermark 
          static readonly Image img = null;
          public override void OnEndPage(PdfWriter writer, Document document)
          {
              img.SetAbsolutePosition(
                  (document.PageSize.Width - img.ScaledWidth) / 4,
                  (document.PageSize.Height - img.ScaledHeight) / 4
                );
              
              writer.DirectContentUnder.SaveState();
              writer.DirectContentUnder.SetGState(new PdfGState() { FillOpacity = 0.5f });
              writer.DirectContentUnder.AddImage(img, true);
              writer.DirectContentUnder.RestoreState();
          }
      }
      public void Write(Stream stream)
      {
          var reader = new PdfReader(INPUT_PDF);
          using (reader)
          {
              using (Document document = new Document())
              {
                  // trick is to use page events
                  PdfWriter writer = PdfWriter.GetInstance(document, stream);
                  writer.PageEvent = new TextWatermarkPdfPageEventHelper();
                  writer.PageEvent = new ImageWatermarkPdfPageEventHelper();
                  document.Open();
                  var n = reader.NumberOfPages;
                  // dump pages from source, watermarks will be added OnEndPage
                  for (int i = 1; i <= n; i++)
                  {
                      document.NewPage();
                      var pagei = writer.GetImportedPage(reader, i);
                      writer.DirectContentUnder.AddTemplate(pagei, 0, 0);
                  }
              }
          }
        }
    }
