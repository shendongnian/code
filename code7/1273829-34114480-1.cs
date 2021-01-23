    public class ArrowAdorner : Adorner
        {
            private FrameworkElement _adornedElement;
            public ArrowAdorner(FrameworkElement adornedElement)
                : base(adornedElement)
            {
                _adornedElement = adornedElement;
            }
    
            protected override void OnRender(DrawingContext drawingContext)
            {
                var height = _adornedElement.ActualHeight;
                var width = _adornedElement.ActualWidth;    
               
    
                drawingContext.DrawLine(new Pen(Brushes.Red, 3), new Point(width, 0), new Point(width, height));
                drawingContext.DrawLine(new Pen(Brushes.Red, 3), new Point(width,0), new Point(width / 2, height / 2));
                drawingContext.DrawLine(new Pen(Brushes.Red, 3), new Point(width, height), new Point(width / 2, height / 2));
            }
        }
