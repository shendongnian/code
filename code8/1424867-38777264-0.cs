    using System;
    using Word = Microsoft.Office.Interop.Word;
    
    namespace WordAddIn1
    {
        public class Class1
        {
            public void InsertShape(Word.Document doc)
            {
                try
                {
                    Word.Section sec = doc.Sections[1];
                    Word.HeaderFooter foo = sec.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
    
                    Word.Range rng = foo.Range;
    
                    float leftPos = doc.PageSetup.PageWidth - doc.PageSetup.RightMargin;
                    float topPos = doc.PageSetup.PageHeight - doc.PageSetup.BottomMargin;
    
                    Word.Shape shp = doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,
                                                           leftPos, topPos, 50, 20, rng);
    
                    shp.TextFrame.TextRange.Text = "Text";
                    shp.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionBottomMarginArea;
    
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
