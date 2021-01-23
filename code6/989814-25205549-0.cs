    public class SingleCellFieldPositioningEvent : IPdfPCellEvent {
        public TextField Field { get; set; }
        public PdfWriter Writer { get; set; }
        public float Padding { get; set; }
        public SingleCellFieldPositioningEvent(PdfWriter writer, TextField field) {
            this.Field = field;
            this.Writer = writer;
        }
        public SingleCellFieldPositioningEvent(PdfWriter writer, string fieldName, string text = "", BaseFont font = null, float fontSize = 14 ) {
            //The rectangle gets changed later so it doesn't matter what we use
            var rect = new iTextSharp.text.Rectangle(1, 1);
            //Create the field and set various properties
            this.Field = new TextField(writer, rect, fieldName);
            this.Field.Text = text;
            if (null == font) {
                font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
            }
            this.Field.Font = font;
            this.Field.FontSize = fontSize;
            this.Writer = writer;
        }
        public void CellLayout(PdfPCell cell, iTextSharp.text.Rectangle rect, PdfContentByte[] canvases) {
            //Create the field's rectangle based on the current cell and requested padded
            var newRect = new PdfRectangle(rect.GetLeft(Padding), rect.GetBottom(Padding), rect.GetRight(Padding), rect.GetTop(Padding));
            //Set the appearance's rectangle to the same as the box
            Field.Box = newRect.Rectangle;
            //Get the raw field
            var tf = this.Field.GetTextField();
            //Change the field's rectangle
            tf.Put(PdfName.RECT, newRect);
            //Add the annotation to the writer
            Writer.AddAnnotation(tf);
        }
    }
