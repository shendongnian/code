    [DebuggerDisplay("[{Scene}]Strokes:{Strokes.Count}, Children:{Children.Count}")]
    public class InkCanvas_Sandeep : InkCanvas
    {
        public int PagId = -1;
        public InkCanvas_Sandeep()
        {
            DefaultDrawingAttributes.Color = Colors.Red;
            DefaultDrawingAttributes.FitToCurve = true;
            DefaultDrawingAttributes.Height = 2;
            DefaultDrawingAttributes.Width = 2;
            DefaultDrawingAttributes.IgnorePressure = false;
            DefaultDrawingAttributes.IsHighlighter = false;
            DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Ellipse;
            DefaultDrawingAttributes.StylusTipTransform = Matrix.Identity;
            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            SnapsToDevicePixels = true;
        }
    }
    public void createMultipleInstances()
    {
        InkCanvas_Sandeep canvas new InkCanvas_Sandeep();
        canvas.PagId = ++PageDetails.PageId;
    }
