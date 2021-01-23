    public class MyCanvas : Canvas
    {
        protected override Size MeasureOverride(Size constraint)
        {
            Size desiredSize = new Size();
            foreach (UIElement child in this.Children)
            {
                // This is your "control" 
                child.Measure(constraint);
                // This is the size of the "control".
                var myControlSize = child.DesiredSize;
            }
            return desiredSize;
        }
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            // When this is called, you should know the DesiredSize of each control
            // and you can decide where each control location relative to the canvas.
            return arrangeSize;
        }
    }
