    public class Drawing : FrameworkElement
    {
        private readonly VisualCollection _visuals;
    
        private int width;
        public int VisualWidth
        {
            get { return width; }
            set
            {
                width = value;
                RefreshDrawing();
            }
        }
    
        public Drawing()
        {
            RenderOptions.SetEdgeMode(this, EdgeMode.Aliased);
            _visuals = new VisualCollection(this);
    
            var geometryGroup = new GeometryGroup();
            width = 50;
            DrawingVisual drawingVisual = new DrawingVisual();
            RefreshDrawing(drawingVisual);
            _visuals.Add(drawingVisual);
        }
    
        private void RefreshDrawing(DrawingVisual drawingVisual = null)
        {
            var geometryGroup = new GeometryGroup();
            var rect = new Rect(50, 50, VisualWidth, 50);
            var rectGeom = new RectangleGeometry(rect);
            geometryGroup.Children.Add(rectGeom);
            geometryGroup.Freeze();
    
            drawingVisual = drawingVisual ?? (DrawingVisual)GetVisualChild(0);
            using (var dc = drawingVisual.RenderOpen())
            {
                dc.DrawGeometry(Brushes.Blue, null, geometryGroup);
            }
        }
    
        protected override Visual GetVisualChild(int index)
        {
            return _visuals[0];
        }
    
        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }
    }
