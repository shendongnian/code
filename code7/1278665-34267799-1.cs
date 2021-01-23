    public class ControlAdorner : Adorner {
        FrameworkElement _control;
        public FrameworkElement Control {
            get {
                return (_control);
            }
            set {
                _control = value;
            }
        }
        public ControlAdorner(UIElement Element, FrameworkElement Control)
            : base(Element) {
            this.Control = Control;
            this.AddVisualChild(this.Control);
            this.IsHitTestVisible = false;
        }
        protected override Visual GetVisualChild(int index) {
            if (index != 0) throw new ArgumentOutOfRangeException();
            return _control;
        }
        protected override int VisualChildrenCount {
            get {
                return 1;
            }
        }
        public void UpdatePosition(Point point) {
            VisualOffset = new Vector(point.X, point.Y);
            this.InvalidateVisual();
        }
        protected override Size MeasureOverride(Size constraint) {
            Control.Measure(constraint);
            return Control.DesiredSize;
        }
        protected override Size ArrangeOverride(Size finalSize) {
            Control.Arrange(new Rect(new Point(VisualOffset.X, VisualOffset.Y - 20), finalSize));
            return new Size(Control.ActualWidth, Control.ActualHeight);
        }
    }
