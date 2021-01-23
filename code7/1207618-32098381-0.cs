    Microsoft.Office.Interop.PowerPoint.Application app = new Microsoft.Office.Interop.PowerPoint.Application();
    var pps = app.Presentations;
    string d ="filepath.pptx";
    Presentation ppt = pps.Open(d, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
    for (int j = 1; j < ppt.Slides.Count; j++)
    {
        Slide sld = ppt.Slides[j];
        List<Microsoft.Office.Interop.PowerPoint.Shape> shapes = new List<Microsoft.Office.Interop.PowerPoint.Shape>();
        for (int k = 1; k < sld.Shapes.Count; k++)
        {
            Microsoft.Office.Interop.PowerPoint.Shape shape = sld.Shapes[k]; 
            shape.Export("outputFilePath.wmf", PpShapeFormat.ppShapeFormatWMF);
        }
    }
