    [Test]
    public void ShowAnchorPoints()
    {
        Directory.CreateDirectory(@"C:\Temp\test-results\content\");
        string dest = @"C:\Temp\test-results\content\showAnchorPoints.pdf";
        using (Document document = new Document())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(dest, FileMode.Create, FileAccess.Write));
            document.Open();
            PdfContentByte canvas = writer.DirectContent;
            canvas.MoveTo(300, 100);
            canvas.LineTo(300, 700);
            canvas.MoveTo(100, 300);
            canvas.LineTo(500, 300);
            canvas.MoveTo(100, 400);
            canvas.LineTo(500, 400);
            canvas.MoveTo(100, 500);
            canvas.LineTo(500, 500);
            canvas.Stroke();
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, new Phrase("Left aligned"), 300, 500, 0);
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_CENTER, new Phrase("Center aligned"), 300, 400, 0);
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_RIGHT, new Phrase("Right aligned"), 300, 300, 0);
        }
    }
