    public class RoundedBorderLeft : IPdfPCellEvent
    {
        public void CellLayout(PdfPCell cell, Rectangle rect, PdfContentByte[] canvas)
        {
            PdfContentByte cb = canvas[PdfPTable.BACKGROUNDCANVAS];
            cb.SetRGBColorStroke(42, 177, 195);
            cb.RoundRectangle(
             **rect.Left + 40f,**
             rect.Bottom + 1.5f,
            rect.Width - 20,
            rect.Height - 3, 4
             );
            cb.Stroke();
        }
    }
