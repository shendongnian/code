    public class Graph : UIElement
    {
        TranslateTransform _transform = new TranslateTransform() { X = 500, Y = 500 };
        public Graph()
        {
            CacheMode = new BitmapCache(1.4); //decrease this number to improve performance on the cost of quality, increasing improves quality 
            this.RenderTransform = _transform;
            IsHitTestVisible = false;
        }
        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);
            if (VisualParent != null)
                (VisualParent as FrameworkElement).MouseMove += (s, a) => OnMouseMoveHandler(a);
        }
        protected override void OnRender(DrawingContext context)
        {
            // designer bugfix
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            // generate some big figure (try to vary that 2000!)
            var radius = 1.0;
            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext ctx = geometry.Open())
            {
                Point start = new Point(radius * Math.Sin(0), radius * Math.Cos(0));
                ctx.BeginFigure(start, false, false);
                for (int i = 1; i < 5000; i++, radius += 0.1)
                {
                    Point current = new Point(radius * Math.Sin(i), radius * Math.Cos(i));
                    ctx.LineTo(current, true, false);
                }
            }
            //var geometry = new PathGeometry(new[] { new PathFigure(figures[0].Point, figures, false) });
            geometry.Freeze();
            Pen pen = new Pen(Brushes.Black, 5);
            pen.Freeze();
            context.DrawGeometry(null, pen, geometry);
            // measure time
            var time = watch.ElapsedMilliseconds;
            Dispatcher.InvokeAsync(() =>
            {
                Application.Current.MainWindow.Title = string.Format("{0:000}ms; {1:000}ms", time, watch.ElapsedMilliseconds);
            }, DispatcherPriority.Loaded);
        }
        protected void OnMouseMoveHandler(MouseEventArgs e)
        {
            var mouse = e.GetPosition(VisualParent as FrameworkElement);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _transform.X = mouse.X;
                _transform.Y = mouse.Y;
            }
        }
    }
