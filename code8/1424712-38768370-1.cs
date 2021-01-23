    public class HueWheel : Slider
    {
        static HueWheel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HueWheel), new FrameworkPropertyMetadata(typeof(HueWheel)));
        }
        private bool _isPressed = false;
        private Canvas _PART_FirstCanvas;
        private Canvas _PART_SecondCanvas;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _PART_FirstCanvas = (Canvas)GetTemplateChild("PART_FirstCanvas");
            _PART_SecondCanvas = (Canvas)GetTemplateChild("PART_SecondCanvas");
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isPressed)
            {
                const double RADIUS = 150;
                //  Or _PART_SecondCanvas; whichever. 
                Point newPos = e.GetPosition(_PART_FirstCanvas);
                double angle = MyHelper.GetAngleR(newPos, RADIUS);
                //huewheel.Value = (huewheel.Maximum - huewheel.Minimum) * angle / (2 * Math.PI);
            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            _isPressed = true;
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            _isPressed = false;
        }
    }
