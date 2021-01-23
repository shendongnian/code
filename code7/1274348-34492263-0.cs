    public bool FindAndHighlightMathtypeEquation(ref Word.Range myRange)
    {
    try
    {
    int inlineShapesCount = myRange.InlineShapes.Count;
    if (inlineShapesCount > 0)
    {
    for(int i = 1;i<= inlineShapesCount; i++)
    {
    Word.InlineShape currentShape = myRange.InlineShapes[i];
    Word.Range currentShapeRange = currentShape.Range;
    Word.WdInlineShapeType typeOfCurrentShape = currentShape.Type;
    
    if (typeOfCurrentShape != Word.WdInlineShapeType.wdInlineShapeEmbeddedOLEObject)
    {
    continue;
    }
    
    if (!currentShape.Field.Code.Text.Trim().ToLower().Contains("equation"))
    {
    continue;
    }
    
    currentShapeRange.Select();
    currentShapeRange.Application.Selection.Range.HighlightColorIndex = Word.WdColorIndex.wdYellow;
    }
    }
    
    MessageBox.Show("Process Completed");
    
    }
    catch (Exception)
    {
    throw;
    }
    return true;
    }
