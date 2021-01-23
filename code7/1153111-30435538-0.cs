    foreach (Microsoft.Office.Interop.PowerPoint.Slide slide in pp.Slides)
    {
       foreach (Microsoft.Office.Interop.PowerPoint.Shape shape in slide.Shapes)
       {
            if(shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
            {
               var textFrame = shape.TextFrame;
               if(textFrame.HasText == Microsoft.Office.Core.MsoTriState.msoTrue)
               {
                  var textRange = textFrame.TextRange;
                  pps += textRange.Text.ToString ();
               }
            }
            
       }
    }
