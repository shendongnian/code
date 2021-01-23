    public class pdfCellBorder : IPdfPCellEvent {
        public void CellLayout(PdfPCell cell, iTextSharp.text.Rectangle position, PdfContentByte[] canvases) {
            PdfContentByte canvas = canvases[PdfPTable.LINECANVAS];
            canvas.SetLineDash(0.5F, 2.2F, 0);
            //Move the "pen" to where we want to start drawing
            canvas.MoveTo(position.Left, position.Bottom);
            //Draw a straight line
            canvas.LineTo(position.Right, position.Bottom);
            canvas.Stroke();
        }
    }
