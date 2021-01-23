    using Word = Microsoft.Office.Interop.Word
    
    var WORD = new Word.Application();
    Word.Document doc   = WORD.Documents.Open(@PATH_APP);
    doc.Activate();
    
    foreach (Microsoft.Office.Interop.Word.Shape shape in WORD.ActiveDocument.Shapes)
    {
        if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoTextBox)
        {
            if (shape.AlternativeText.Contains("MY_FIELD_TO_OVERWRITE_OO1"))
            {       
                 shape.TextFrame.TextRange.Text="MY_NEW_FIELD_VALUE";
            }
                                
        }
    }
        
    doc.Save();
