    using System;
    using System.Collections.Generic;
    using Microsoft.Office.Core;
    using PowerPoint = Microsoft.Office.Interop.PowerPoint;
    
    namespace Mintra.Publisher.DocumentConverter.Core.Utils
    {
        class InteropUtility
        {
    
    
            public static IList<string> GetPresentationTitles(string pptPath)
            {
    
                IList<string> result = new List<string>();
    
                var presentationApp = new Microsoft.Office.Interop.PowerPoint.Application();
    
                try
                {
                    presentationApp.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                    Microsoft.Office.Interop.PowerPoint.Presentations presentations = presentationApp.Presentations;
    
                    var readOnly = Microsoft.Office.Core.MsoTriState.msoTrue;
                    var untitled = Microsoft.Office.Core.MsoTriState.msoTrue;
                    var withWindow = Microsoft.Office.Core.MsoTriState.msoFalse;
    
                    Microsoft.Office.Interop.PowerPoint.Presentation presentation = presentations.Open(pptPath, readOnly, untitled, withWindow);
                    int i = 0;
                    foreach (PowerPoint.Slide slide in presentation.Slides)
                    {
                        string defaultTitle = String.Format("Slide {0}", i);
                        String shapeTitle = ExtractSlideTitlefromShape(slide, defaultTitle);
                        result.Add(shapeTitle);
                    }
                }
                finally
                {
                    presentationApp.Quit();
                }
    
    
                return result;
    
            }
    
            private static string ExtractSlideTitlefromShape(PowerPoint.Slide slide, string defaultValue)
            {
                PowerPoint.HeadersFooters headersFooters = slide.HeadersFooters;
                PowerPoint.Shapes mastershapes = slide.Master.Shapes;
    
                for (int i = 1; i <= slide.Shapes.Count; i++)
                {
                    PowerPoint.Shape shape = slide.Shapes[i];
                    bool hasTextFrame = shape.HasTextFrame == MsoTriState.msoTrue;
                    bool isTypePlaceholder = shape.Type.Equals(MsoShapeType.msoPlaceholder);
                    bool hasTextInTextFrame = shape.TextFrame.HasText == MsoTriState.msoTrue;
                    bool isTitleShape = shape.Name.ToLower().Contains("title");
    
                    if (isTypePlaceholder && hasTextFrame && hasTextInTextFrame && isTitleShape)
                    {
                        return shape.TextFrame.TextRange.Text;
    
                    }
                }
    
                return defaultValue;
            }
    
        }
    }
