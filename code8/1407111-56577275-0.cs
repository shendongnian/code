        private void ImageToDocx(List<string> Images)
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document wordDoc = wordApp.Documents.Add();
                Range docRange = wordDoc.Range();
    
                float mHeight = 0;
                for (int i = 0; i <= Images.Count - 1; i++)
                {
                    // Create an InlineShape in the InlineShapes collection where the picture should be added later
                    // It is used to get automatically scaled sizes.
                    InlineShape autoScaledInlineShape = docRange.InlineShapes.AddPicture(Images[i]);
                    float scaledWidth = autoScaledInlineShape.Width;
                    float scaledHeight = autoScaledInlineShape.Height;
                    mHeight += scaledHeight;
                    autoScaledInlineShape.Delete();
    
                    // Create a new Shape and fill it with the picture
                    Shape newShape = wordDoc.Shapes.AddShape(1, 0, 0, scaledWidth, mHeight);
                    newShape.Fill.UserPicture(Images[i]);
    
                    // Convert the Shape to an InlineShape and optional disable Border
                    InlineShape finalInlineShape = newShape.ConvertToInlineShape();
                    finalInlineShape.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
    
                    // Cut the range of the InlineShape to clipboard
                    finalInlineShape.Range.Cut();
    
                    // And paste it to the target Range
                    docRange.Paste();
                }
    
                wordDoc.SaveAs2(@"c:\temp\test.docx");
                wordApp.Quit();
    }
