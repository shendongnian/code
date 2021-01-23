    public class Graph : UIElement
    {
        DrawingVisual drawing;
        VisualCollection _visuals;
        TranslateTransform _transform = new TranslateTransform() { X = 200, Y = 200 };
        public Graph()
        {
            _visuals = new VisualCollection(this);
            drawing = new DrawingVisual();
            drawing.Transform = _transform;
            drawing.CacheMode = new BitmapCache(1);
            _visuals.Add(drawing);
            Render();
        }
        protected void Render()
        {
            // designer bugfix
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            using (DrawingContext context = drawing.RenderOpen())
            {
                // generate some big figure (try to vary that 2000!)
                var radius = 1.0;
                StreamGeometry geometry = new StreamGeometry();
                using (StreamGeometryContext ctx = geometry.Open())
                {
                    Point start = new Point(radius * Math.Sin(0), radius * Math.Cos(0));
                    ctx.BeginFigure(start, false, false);
                    for (int i = 1; i < 2000; i++, radius += 0.1)
                    {
                        Point current = new Point(radius * Math.Sin(i), radius * Math.Cos(i));
                        ctx.LineTo(current, true, false);
                    }
                }
                geometry.Freeze();
                Pen pen = new Pen(Brushes.Black, 1);
                pen.Freeze();
                // measure time
                var time = watch.ElapsedMilliseconds;
                context.DrawGeometry(null, pen, geometry);
                Dispatcher.InvokeAsync(() =>
                {
                    Application.Current.MainWindow.Title = string.Format("{0:000}ms; {1:000}ms", time, watch.ElapsedMilliseconds);
                }, DispatcherPriority.Normal);
            }
        }
        protected override Visual GetVisualChild(int index)
        {
            return drawing;
        }
        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var mouse = e.GetPosition(VisualParent as FrameworkElement);
                _transform.X = mouse.X;
                _transform.Y = mouse.Y;
            }
            base.OnMouseMove(e);
        }
    }
