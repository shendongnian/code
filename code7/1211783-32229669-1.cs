    foreach (Word.Paragraph paragraph in myDocument.Paragraphs)
    {
       string pText = paragraph.Range.Text;
       System.Diagnostics.Debug.WriteLine(pText);
       Word.InlineShapes shapes = paragraph.Range.InlineShapes;
       System.Diagnostics.Debug.WriteLine("Shape Count: " + shapes.Count);
    }
