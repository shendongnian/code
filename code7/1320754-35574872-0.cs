    public class GradientTableBackground : IPdfPTableEvent
    {
        public GradientTableBackground(PdfWriter writer)
        {
            this.writer = writer;
        }
        public void TableLayout(PdfPTable table, float[][] widths, float[] heights, int headerRows, int rowStart, PdfContentByte[] canvases)
        {
            BaseColor gradientStart = ...;
            BaseColor gradientEnd = ...);
            float[] topWidths = widths[0];
            PdfContentByte cb = canvases[PdfPTable.BACKGROUNDCANVAS];
            Rectangle rectangle = new Rectangle(topWidths[0], heights[heights.Length - 1], topWidths[topWidths.Length - 1], heights[0]);
            PdfShading shading = PdfShading.SimpleAxial(writer, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom, gradientStart, gradientEnd);
            PdfShadingPattern pattern = new PdfShadingPattern(shading);
            cb.SetShadingFill(pattern);
            cb.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
            cb.Fill();
        }
        PdfWriter writer;
    }
