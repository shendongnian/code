        public int XGridStep
        {
            get { return (int)base.GetValue(XGridStepProperty); }
            set
            {
                base.SetValue(XGridStepProperty, value);
                RepaintGrid();
            }
        }
        public static readonly DependencyProperty XGridStepProperty = DependencyProperty.Register("XGridStepProperty", typeof(int), typeof(PlanLayout), new PropertyMetadata(100));
        public int XGridOffset
        {
            get { return (int)base.GetValue(XGridOffsetProperty); }
            set
            {
                base.SetValue(XGridOffsetProperty, value);
                RepaintGrid();
            }
        }
        public static readonly DependencyProperty XGridOffsetProperty = DependencyProperty.Register("XGridOffsetProperty", typeof(int), typeof(PlanLayout), new PropertyMetadata(0));
        public bool XGridVisible
        {
            get { return (bool)base.GetValue(XGridVisibleProperty); }
            set
            {
                base.SetValue(XGridVisibleProperty, value);
                RepaintGrid();
            }
        }
        public static readonly DependencyProperty XGridVisibleProperty = DependencyProperty.Register("XGridVisibleProperty", typeof(bool), typeof(PlanLayout), new PropertyMetadata(false));
        public int YGridStep
        {
            get { return (int)base.GetValue(YGridStepProperty); }
            set
            {
                base.SetValue(YGridStepProperty, value);
                RepaintGrid();
            }
        }
        public static readonly DependencyProperty YGridStepProperty = DependencyProperty.Register("YGridStepProperty", typeof(int), typeof(PlanLayout), new PropertyMetadata(100));
        public int YGridOffset
        {
            get { return (int)base.GetValue(YGridOffsetProperty); }
            set
            {
                base.SetValue(YGridOffsetProperty, value);
                RepaintGrid();
            }
        }
        public static readonly DependencyProperty YGridOffsetProperty = DependencyProperty.Register("YGridOffsetProperty", typeof(int), typeof(PlanLayout), new PropertyMetadata(0));
        public bool YGridVisible
        {
            get { return (bool)base.GetValue(YGridVisibleProperty); }
            set
            {
                base.SetValue(YGridVisibleProperty, value);
                RepaintGrid();
            }
        }
        public static readonly DependencyProperty YGridVisibleProperty = DependencyProperty.Register("YGridVisibleProperty", typeof(bool), typeof(PlanLayout), new PropertyMetadata(false));
        private void RepaintGrid()
        {
            if (!IsEditable)
                return;
            foreach (Line l in _gridXLines)
                content.Children.Remove(l);
            _gridXLines.Clear();
            if (XGridVisible)
                for (int i = XGridOffset; i < content.ActualWidth; i += XGridStep)
                {
                    Line line = new Line();
                    line.IsHitTestVisible = false;
                    line.Stroke = Brushes.Black;
                    line.Y1 = 0;
                    line.Y2 = content.ActualHeight;
                    line.X1 = line.X2 = i;
                    if (Math.Abs(line.X1 - content.ActualWidth) < XGridStep * 0.5 || line.X1 < XGridStep * 0.5)
                        continue;
                    _gridXLines.Add(line);
                    content.Children.Add(line);
                    Canvas.SetZIndex(line, 0);
                }
            foreach (Line l in _gridYLines)
                content.Children.Remove(l);
            _gridYLines.Clear();
            if (YGridVisible)
                for (int i = YGridOffset; i < content.ActualHeight; i += YGridStep)
                {
                    Line line = new Line();
                    line.IsHitTestVisible = false;
                    line.Stroke = Brushes.Black;
                    line.X1 = 0;
                    line.X2 = content.ActualWidth;
                    line.Y1 = line.Y2 = i;
                    if (Math.Abs(line.Y1 - content.ActualHeight) < YGridStep * 0.5 || line.Y1 < YGridStep * 0.5)
                        continue;
                    _gridYLines.Add(line);
                    content.Children.Add(line);
                    Canvas.SetZIndex(line, 0);
                }
        }
