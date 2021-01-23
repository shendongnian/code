    Application wordApp = new Application();
    Document wordDoc = wordApp.Documents.Add();
    Range docRange = wordDoc.Range();
    
    string imagePath = @"c:\temp\win10.jpg";
    
    // Create an InlineShape in the InlineShapes collection where the picture should be added later
    // It is used to get automatically scaled sizes.
    InlineShape autoScaledInlineShape = docRange.InlineShapes.AddPicture(imagePath);
    float scaledWidth = autoScaledInlineShape.Width;
    float scaledHeight = autoScaledInlineShape.Height;
    autoScaledInlineShape.Delete();
    
    // Create a new Shape and fill it with the picture
    Shape newShape = wordDoc.Shapes.AddShape(1, 0, 0, scaledWidth, scaledHeight);
    newShape.Fill.UserPicture(imagePath);
    
    // Convert the Shape to an InlineShape and optional disable Border
    InlineShape finalInlineShape = newShape.ConvertToInlineShape();
    finalInlineShape.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
    
    // Cut the range of the InlineShape to clipboard
    finalInlineShape.Range.Cut();
                
    // And paste it to the target Range
    docRange.Paste();
    
    wordDoc.SaveAs2(@"c:\temp\test.docx");
    wordApp.Quit();
