    foreach (Microsoft.Office.Interop.PowerPoint.Shape shape in slide.Shapes)
    {
      if(shape.TextFrame.HasText)
      {
         pps += shape.TextFrame.TextRange.Text;
      }
    }
