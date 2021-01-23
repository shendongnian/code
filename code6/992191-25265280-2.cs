    public class pdfCellBorder : IPdfPCellEvent {
        public void CellLayout(PdfPCell cell, iTextSharp.text.Rectangle position, PdfContentByte[] canvases) {
            PdfContentByte canvas = canvases[PdfPTable.LINECANVAS];
            canvas.SetLineDash(0.5F, 2.2F, 0);
            //Set the rectangle to draw on
            canvas.Rectangle(position.Left, position.Bottom, position.Width, position.Height);
            canvas.Stroke();
        }
    }
