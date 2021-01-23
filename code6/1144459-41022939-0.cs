        private static string ExtractSlideTitlefromShape(Microsoft.Office.Interop.PowerPoint.Slide slide, string defaultValue)
        {
            if (slide.Shapes.HasTitle == Office.MsoTriState.msoTrue)
            {
                if (slide.Shapes.Title.TextFrame.HasText == Office.MsoTriState.msoTrue)
                {
                    return slide.Shapes.Title.TextFrame.TextRange.Text;
                }
            }
            return defaultValue;
        }
