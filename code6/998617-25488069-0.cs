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
                Point previous = new Point(radius * Math.Sin(0) + _offset.X, radius * Math.Cos(0) + _offset.Y);
                ctx.BeginFigure(previous, false, false);
                for (int i = 1; i < 2000; i++, radius += 0.1)
                {
                    Point current = new Point(radius * Math.Sin(i) + _offset.X, radius * Math.Cos(i) + _offset.Y);
                    ctx.LineTo(current, true, false);
                    previous = current;
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
                Window.GetWindow(this).Title = string.Format("{0:000}ms; {1:000}ms", time, watch.ElapsedMilliseconds);
            }, DispatcherPriority.Loaded);
        }
