    public class pageborder : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            var content = writer.DirectContent;
            content.SetColorStroke(BaseColor.BLACK);
            content.RoundRectangle(35f,55f, 520f, 750f ,20f);
            content.Stroke();        
        }    
    }
