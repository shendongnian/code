    public class pageborder : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            var content = writer.DirectContent;
            content.SetColorFill(BaseColor.RED);
            content.RoundRectangle(35f,55f, 520f, 750f ,20f);
            content.Fill();        
        }    
    }
